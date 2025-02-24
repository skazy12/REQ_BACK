using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class PermisoRepositorio : IPermisoRepositorio
    {
        private readonly AplicacionDbContext _contexto;

        public PermisoRepositorio(AplicacionDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Permiso>> ObtenerPermisosAsync()
        {
            return await _contexto.Permisos.ToListAsync();
        }

        public async Task CrearPermisoAsync(Permiso permiso)
        {
            _contexto.Permisos.Add(permiso);
            await _contexto.SaveChangesAsync();
        }

        public async Task ModificarPermisoAsync(int id, Permiso permiso)
        {
            var permisoExistente = await _contexto.Permisos.FindAsync(id);
            if (permisoExistente != null)
            {
                permisoExistente.Descripcion = permiso.Descripcion;
                permisoExistente.Activo = permiso.Activo;

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task DesactivarPermisoAsync(int id)
        {
            var permiso = await _contexto.Permisos.FindAsync(id);
            if (permiso != null)
            {
                permiso.Activo = false;
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
