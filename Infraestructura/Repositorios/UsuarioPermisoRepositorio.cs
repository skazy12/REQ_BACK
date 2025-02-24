using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Repositorios
{
    public class UsuarioPermisoRepositorio : IUsuarioPermisoRepositorio
    {
        private readonly AplicacionDbContext _contexto;

        public UsuarioPermisoRepositorio(AplicacionDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<UsuarioPermiso>> ObtenerUsuarioPermisosAsync()
        {
            return await _contexto.UsuarioPermisos.ToListAsync();
        }

        public async Task<UsuarioPermiso> ObtenerUsuarioPermisoPorIdAsync(int id)
        {
            return await _contexto.UsuarioPermisos.FindAsync(id);
        }

        public async Task CrearUsuarioPermisoAsync(UsuarioPermiso usuarioPermiso)
        {
            _contexto.UsuarioPermisos.Add(usuarioPermiso);
            await _contexto.SaveChangesAsync();
        }

        public async Task ModificarUsuarioPermisoAsync(int id, UsuarioPermiso usuarioPermiso)
        {
            var existente = await _contexto.UsuarioPermisos.FindAsync(id);
            if (existente != null)
            {
                existente.UsuarioCodAgenda = usuarioPermiso.UsuarioCodAgenda;
                existente.PermisoId = usuarioPermiso.PermisoId;
                existente.ModificadoPor = usuarioPermiso.ModificadoPor;

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task DesactivarUsuarioPermisoAsync(int id)
        {
            var existente = await _contexto.UsuarioPermisos.FindAsync(id);
            if (existente != null)
            {
                _contexto.UsuarioPermisos.Remove(existente);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
