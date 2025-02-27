
using Aplicacion.Interfaces;
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
            services.AddScoped<IPermisoRepositorio, PermisoRepositorio>();
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();
            services.AddScoped<ICargoPermisoRepositorio, CargoPermisoRepositorio>();


            // 🔹 Registrar Servicios de Aplicación
            services.AddScoped<IPermisoServicio, PermisoServicio>();
            services.AddScoped<ICargoServicio, CargoServicio>();
            services.AddScoped<ICargoPermisoServicio, CargoPermisoServicio>();

            return services;
        }
    }
}
