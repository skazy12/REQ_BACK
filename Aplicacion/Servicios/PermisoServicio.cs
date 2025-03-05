using Aplicacion.DTOs;
using Aplicacion.Interfaces;

namespace Aplicacion.Servicios
{
    public class PermisoServicio : IPermisoServicio
    {
        private readonly IPermisoRepositorio _permisoRepositorio;

        public PermisoServicio(IPermisoRepositorio permisoRepositorio)
        {
            _permisoRepositorio = permisoRepositorio;
        }

        public async Task<IEnumerable<PermisoDTO>> ObtenerTodosAsync()
        {
            return await _permisoRepositorio.ObtenerTodosAsync();
        }

        public async Task<PermisoDTO> ObtenerPorIdAsync(int id)
        {
            return await _permisoRepositorio.ObtenerPorIdAsync(id);
        }

        public async Task AgregarAsync(PermisoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Descripcion))
                throw new ArgumentException("La descripción del permiso es obligatoria.");

            dto.CreadoPor = "admin"; // Asigna el usuario logueado como creador
            await _permisoRepositorio.AgregarAsync(dto);
        }

        public async Task ModificarAsync(PermisoDTO dto)
        {
            await _permisoRepositorio.ModificarAsync(dto);
        }

        public async Task DesactivarAsync(int id)
        {
            await _permisoRepositorio.DesactivarAsync(id);
        }
    }
}
