using Aplicacion.Interfaces;
using Aplicacion.Servicios;
using Infraestructura.Persistencia;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructura
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarInfraestructura(
            this IServiceCollection services, IConfiguration configuration)
        {
            // 🔹 Obtener la cadena de conexión desde API
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("No se encontró la cadena de conexión en la configuración.");
            }

            // 🔹 Registrar la conexión a la base de datos
            services.AddDbContext<AplicacionDbContext>(options =>
                options.UseSqlServer(connectionString));

            // 🔹 Registrar Repositorios
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            services.AddScoped<IPermisoRepositorio, PermisoRepositorio>();
            services.AddScoped<IJerarquiaCargosRepositorio, JerarquiaCargosRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IUsuarioPermisoRepositorio, UsuarioPermisoRepositorio>();
            services.AddScoped<ICargoPermisoRepositorio, CargoPermisoRepositorio>();
            services.AddScoped<IUsuarioCargoRepositorio, UsuarioCargoRepositorio>();

            // 🔹 Registrar Servicios de Aplicación
            services.AddScoped<ICargoServicio, CargoServicio>();
            services.AddScoped<IPermisoServicio, PermisoServicio>();
            services.AddScoped<IJerarquiaCargosServicio, JerarquiaCargosServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IUsuarioPermisoServicio, UsuarioPermisoServicio>();
            services.AddScoped<ICargoPermisoServicio, CargoPermisoServicio>();
            services.AddScoped<IUsuarioCargoServicio, UsuarioCargoServicio>();

            return services;
        }
    }
}
