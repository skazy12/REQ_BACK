using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Excepciones;
using Aplicacion.Interfaces.IRepositorios;
using Aplicacion.Interfaces.IServicios;

namespace Aplicacion.Servicios
{
    public class UsuarioPermisoServicio : IUsuarioPermisoServicio
    {
        private readonly IUsuarioPermisoRepositorio _usuarioPermisoRepositorio;

        public UsuarioPermisoServicio(IUsuarioPermisoRepositorio usuarioPermisoRepositorio)
        {
            _usuarioPermisoRepositorio = usuarioPermisoRepositorio;
        }

        public async Task<IEnumerable<UsuarioPermisoDTO>> ObtenerPermisosPorUsuarioAsync(string usuarioCodAgenda)
        {
            try
            {
                var permisos = await _usuarioPermisoRepositorio.ObtenerPermisosPorUsuarioAsync(usuarioCodAgenda);

                if (permisos == null)
                    throw new ExcepcionNoEncontrado($"No se encontraron permisos para el usuario con código de agenda '{usuarioCodAgenda}'.");

                return permisos;
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio($"Error al obtener permisos del usuario: {ex.Message}");
            }
        }
        public async Task ActualizarPermisoUsuarioAsync(string usuarioCodAgenda, List<UsuarioPermisoDTO> permisos)
        {
            try
            {
                if (permisos == null || permisos.Count == 0)
                    throw new ExcepcionNegocio("La lista de permisos no puede estar vacía.");

                string modificadoPor = "admin"; // En el futuro se debe obtener del usuario autenticado

                await _usuarioPermisoRepositorio.ActualizarPermisoUsuarioAsync(usuarioCodAgenda, permisos, modificadoPor);
            }
            catch (Exception ex)
            {
                throw new ExcepcionNegocio($"Error al actualizar permisos del usuario: {ex.Message}");
            }
        }
    }
}
