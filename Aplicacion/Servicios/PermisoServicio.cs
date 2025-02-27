using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class PermisoServicio : IPermisoServicio
    {
        private readonly IPermisoRepositorio _repositorio;

        public PermisoServicio(IPermisoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<PermisoDTO>> ObtenerTodosAsync()
        {
            var permisos = await _repositorio.ObtenerTodosAsync();
            return permisos.Select(p => new PermisoDTO { PermisoId = p.PermisoId, Descripcion = p.Descripcion, Activo = p.Activo });
        }

        public async Task<PermisoDTO> ObtenerPorIdAsync(int id)
        {
            var permiso = await _repositorio.ObtenerPorIdAsync(id);

            if (permiso == null)
                return null; // 🔹 Retorna null si el permiso no existe

            return new PermisoDTO
            {
                PermisoId = permiso.PermisoId,
                Descripcion = permiso.Descripcion,
                Activo = permiso.Activo
            };
        }


        public async Task AgregarAsync(PermisoDTO dto)
        {
            var permiso = new Permiso { Descripcion = dto.Descripcion, Activo = true, CreadoPor = "admin" };
            await _repositorio.AgregarAsync(permiso);
        }

        public async Task ModificarAsync(PermisoDTO dto)
        {
            var permiso = new Permiso { PermisoId = (int)dto.PermisoId, Descripcion = dto.Descripcion, Activo = dto.Activo };
            await _repositorio.ModificarAsync(permiso);
        }

        public async Task DesactivarAsync(int id)
        {
            await _repositorio.DesactivarAsync(id);
        }
    }
}
