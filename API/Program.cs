using Infraestructura;

using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Pasar configuración desde API a Infraestructura
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
var app = builder.Build();

// 🔹 Configurar Middleware
app.UseCors(MyAllowSpecificOrigins);  // Habilita CORS antes de cualquier otro middleware
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();


