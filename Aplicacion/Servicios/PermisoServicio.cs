using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;


namespace Aplicacion.Servicios
{
    public class PermisoServicio : IPermisoServicio
    {
        private readonly IPermisoRepositorio _permisoRepositorio;

        public PermisoServicio(IPermisoRepositorio permisoRepositorio)
        {
            _permisoRepositorio = permisoRepositorio;
        }

        public async Task<IEnumerable<PermisoDto>> ObtenerPermisosAsync()
        {
            var permisos = await _permisoRepositorio.ObtenerPermisosAsync();
            return permisos.Select(p => new PermisoDto
            {
                PermisoId = p.PermisoId,  // Se incluye el ID
                Descripcion = p.Descripcion,
                CreadoPor = p.CreadoPor,  // Se añade para trazabilidad
                Activo = p.Activo
            });
        }
        public async Task CrearPermisoAsync(PermisoDto permisoDto)
        {
            var permiso = new Permiso
            {
                Descripcion = permisoDto.Descripcion,
                Activo = permisoDto.Activo,
                CreadoPor = "ADMIN"
            };

            await _permisoRepositorio.CrearPermisoAsync(permiso);
        }

        public async Task ModificarPermisoAsync(int id, PermisoDto permisoDto)
        {
            var permiso = new Permiso
            {
                PermisoId = id,
                Descripcion = permisoDto.Descripcion,
                Activo = permisoDto.Activo
            };

            await _permisoRepositorio.ModificarPermisoAsync(id, permiso);
        }

        public async Task DesactivarPermisoAsync(int id)
        {
            await _permisoRepositorio.DesactivarPermisoAsync(id);
        }
    }
}
