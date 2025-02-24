using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class CargoPermisoRepositorio : ICargoPermisoRepositorio
    {
        private readonly AplicacionDbContext _context;

        public CargoPermisoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CargoPermiso>> ObtenerCargoPermisosAsync()
        {
            return await _context.CargoPermisos.Where(cp => (bool)cp.Activo).ToListAsync();
        }

        public async Task<CargoPermiso> ObtenerCargoPermisoPorIdAsync(int id)
        {
            return await _context.CargoPermisos.FindAsync(id);
        }

        public async Task CrearCargoPermisoAsync(CargoPermiso cargoPermiso)
        {
            await _context.CargoPermisos.AddAsync(cargoPermiso);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarCargoPermisoAsync(int id, CargoPermiso cargoPermiso)
        {
            var existente = await _context.CargoPermisos.FindAsync(id);
            if (existente != null)
            {
                existente.CargoId = cargoPermiso.CargoId;
                existente.PermisoId = cargoPermiso.PermisoId;
                existente.ModificadoPor = cargoPermiso.ModificadoPor;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesactivarCargoPermisoAsync(int id)
        {
            var existente = await _context.CargoPermisos.FindAsync(id);
            if (existente != null)
            {
                existente.Activo = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}
