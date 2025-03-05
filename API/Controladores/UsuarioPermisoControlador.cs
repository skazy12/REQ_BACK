using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Excepciones;
using Aplicacion.Interfaces.IServicios;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [Route("api/usuarios/{usuarioCodAgenda}/permisos")]
    [ApiController]
    public class UsuarioPermisoControlador : ControllerBase
    {
        private readonly IUsuarioPermisoServicio _usuarioPermisoServicio;

        public UsuarioPermisoControlador(IUsuarioPermisoServicio usuarioPermisoServicio)
        {
            _usuarioPermisoServicio = usuarioPermisoServicio;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioPermisoDTO>>> ObtenerPermisosPorUsuario(string usuarioCodAgenda)
        {
            var permisos = await _usuarioPermisoServicio.ObtenerPermisosPorUsuarioAsync(usuarioCodAgenda);
            if (permisos == null)
                throw new ExcepcionNoEncontrado($"No se encontraron permisos para el usuario {usuarioCodAgenda}");

            return Ok(permisos);
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarPermisoUsuario(string usuarioCodAgenda, [FromBody] List<UsuarioPermisoDTO> permisos)
        {
            await _usuarioPermisoServicio.ActualizarPermisoUsuarioAsync(usuarioCodAgenda, permisos);
            return NoContent();
        }
    }
}
