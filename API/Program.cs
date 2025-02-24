
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 🔹 Configurar Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTodo");
app.UseAuthorization();
app.MapControllers();
app.Run();
