using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Infraestructura;
using Infraestructura.Repositorios;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔹 1️⃣ Registrar Infraestructura
builder.Services.AgregarInfraestructura(builder.Configuration);

// 🔹 Registrar Servicios de Aplicación
builder.Services.AddScoped<ICargoServicio, CargoServicio>();
builder.Services.AddScoped<IPermisoServicio, PermisoServicio>();
builder.Services.AddScoped<IJerarquiaCargosServicio, JerarquiaCargosServicio>();
builder.Services.AddScoped<IUsuarioServicio, UsuarioServicio>();
builder.Services.AddScoped<IUsuarioPermisoServicio, UsuarioPermisoServicio>();
builder.Services.AddScoped<ICargoPermisoServicio, CargoPermisoServicio>();
builder.Services.AddScoped<IUsuarioCargoServicio, UsuarioCargoServicio>();

// 🔹 Registrar Repositorios
builder.Services.AddScoped<ICargoRepositorio, CargoRepositorio>();
builder.Services.AddScoped<IPermisoRepositorio, PermisoRepositorio>();
builder.Services.AddScoped<IJerarquiaCargosRepositorio, JerarquiaCargosRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddScoped<IUsuarioPermisoRepositorio, UsuarioPermisoRepositorio>();
builder.Services.AddScoped<ICargoPermisoRepositorio, CargoPermisoRepositorio>();
builder.Services.AddScoped<IUsuarioCargoRepositorio, UsuarioCargoRepositorio>();





// 🔹 3️⃣ Agregar Controladores 
builder.Services.AddControllers(); // 

// 🔹 4️⃣ Agregar Autorización
builder.Services.AddAuthorization();

// 🔹 5️⃣ Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Gestión de Requerimientos de TI",
        Version = "v1",
        Description = "APIs para la gestion de requeriminetos"
    });
});

// 🔹 6️⃣ Configurar CORS
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

// 🔹 7️⃣ Configurar Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTodo");
app.UseAuthorization();
app.MapControllers(); 

app.Run();

