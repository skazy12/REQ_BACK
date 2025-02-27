// Archivo: Infraestructura/Repositorios/CargoPermisoRepositorio.cs
using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class CargoPermisoRepositorio : ICargoPermisoRepositorio
    {
        private readonly AplicacionDbContext _context;

        public CargoPermisoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisosActivosPorCargoAsync(int cargoId)
        {
            return await _context.Permisos
                .FromSqlRaw($"EXEC sp_ObtenerPermisosActivosPorCargo {cargoId}")
                .ToListAsync();
        }

        public async Task ActualizarPermisoCargoAsync(int cargoId, int permisoId, bool asignado, string modificadoPor)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC sp_ActualizarPermisosCargo @p0, @p1, @p2, @p3",
                cargoId, permisoId, asignado, modificadoPor
            );
        }

    }
}
