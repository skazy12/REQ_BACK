using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class PermisoRepositorio : IPermisoRepositorio
    {
        private readonly AplicacionDbContext _context;
        public PermisoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permiso>> ObtenerTodosAsync()
        {
            return await _context.Permisos.FromSqlRaw("EXEC sp_ObtenerPermisos").ToListAsync();
        }

        public async Task<Permiso> ObtenerPorIdAsync(int id)
        {
            var permisos = await _context.Permisos
                .FromSqlRaw($"EXEC sp_ObtenerPermisoPorId {id}")
                .ToListAsync();  // 🔹 Mantenemos la consulta asincrónica

            return permisos.FirstOrDefault(); // 🔹 Ahora podemos usar FirstOrDefault()
        }



        public async Task AgregarAsync(Permiso permiso)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC sp_AgregarPermiso '{permiso.Descripcion}', '{permiso.CreadoPor}'");
        }

        public async Task ModificarAsync(Permiso permiso)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC sp_ModificarPermiso {permiso.PermisoId}, '{permiso.Descripcion}'");
        }

        public async Task DesactivarAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC sp_DesactivarPermiso {id}");
        }
    }
}
