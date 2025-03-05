using API.Middleware;
using Infraestructura;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Configurar Logging para que se vea en consola
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// 🔹 Configurar servicios en Infraestructura
builder.Services.AgregarInfraestructura(builder.Configuration);

// 🔹 Agregar controladores y autorización
builder.Services.AddControllers();
builder.Services.AddAuthorization();

// 🔹 Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Gestión de Requerimientos de TI",
        Version = "v1",
        Description = "APIs para la gestión de requerimientos"
    });
});

// 🔹 Configurar CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.SetIsOriginAllowed(origin => true)
                  .AllowAnyMethod()
                  .AllowAnyHeader()
                  .AllowCredentials();
        });
});

// 🔹 Configurar Logging de peticiones HTTP
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
});

var app = builder.Build();

// 🔹 Middleware de manejo de errores global (DEBE IR ANTES DE CORS)
app.UseMiddleware<ManejoErroresMiddleware>();

// 🔹 Middleware de logging (para registrar las peticiones HTTP)
app.UseHttpLogging();

// 🔹 Configurar CORS antes de otros middlewares
app.UseCors(MyAllowSpecificOrigins);

// 🔹 Configurar Swagger solo en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔹 Habilitar autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

// 🔹 Mapear controladores de la API
app.MapControllers();

// 🔹 Iniciar la aplicación
app.Run();
