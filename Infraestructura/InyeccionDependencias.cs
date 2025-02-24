using Aplicacion.Interfaces;
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
            // 🔹 Registrar la conexión a la base de datos
            services.AddDbContext<AplicacionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // 🔹 Registrar los repositorios
            services.AddScoped<ICargoRepositorio, CargoRepositorio>();

            return services;
        }
    }
}
