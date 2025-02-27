using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configurar Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot();

// Configurar Swagger para el API Gateway
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Gateway",
        Version = "v1",
        Description = "Gateway para la gestión de requerimientos"
    });

    // Agregar referencia a la API real dentro del API Gateway
    c.AddServer(new OpenApiServer { Url = "http://localhost:5000" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Cargar los endpoints de la API real a través del API Gateway
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Gateway");
    c.SwaggerEndpoint("https://localhost:7228/swagger/v1/swagger.json", "API de Gestión de Requerimientos");
});

app.UseOcelot().Wait();
app.Run();
