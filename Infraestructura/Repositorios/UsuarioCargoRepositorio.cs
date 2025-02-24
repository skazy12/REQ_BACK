using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class UsuarioCargoRepositorio : IUsuarioCargoRepositorio
    {
        private readonly AplicacionDbContext _context;

        public UsuarioCargoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioCargo>> ObtenerTodosAsync()
        {
            return await _context.UsuarioCargos.Where(uc => uc.Activo).ToListAsync();
        }

        public async Task<UsuarioCargo> ObtenerPorIdAsync(int id)
        {
            return await _context.UsuarioCargos.FindAsync(id);
        }

        public async Task CrearAsync(UsuarioCargo usuarioCargo)
        {
            await _context.UsuarioCargos.AddAsync(usuarioCargo);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(int id, UsuarioCargo usuarioCargo)
        {
            var existente = await _context.UsuarioCargos.FindAsync(id);
            if (existente != null)
            {
                existente.UsuarioCodAgenda = usuarioCargo.UsuarioCodAgenda;
                existente.CargoId = usuarioCargo.CargoId;
                existente.AsignadoPor = usuarioCargo.AsignadoPor;
                existente.FechaAsignacion = usuarioCargo.FechaAsignacion;
                existente.FechaRemocion = usuarioCargo.FechaRemocion;
                existente.Activo = usuarioCargo.Activo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DesactivarAsync(int id)
        {
            var existente = await _context.UsuarioCargos.FindAsync(id);
            if (existente != null)
            {
                existente.Activo = false;
                existente.FechaRemocion = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }
    }
}
