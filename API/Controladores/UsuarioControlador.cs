using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controladores
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioControlador : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioControlador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        /// <summary>
        /// Obtiene todos los usuarios con sus permisos y cargos.
        /// </summary>
        [HttpGet("con-permisos-cargos")]
        public async Task<IActionResult> ObtenerUsuariosConPermisosYCargos()
        {
            var resultado = await _usuarioServicio.ObtenerUsuariosConPermisosYCargosAsync();
            return Ok(resultado);
        }
    }
}
