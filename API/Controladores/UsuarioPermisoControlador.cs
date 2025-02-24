using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controladores
{
    [ApiController]
    [Route("api/usuario-permisos")]
    public class UsuarioPermisoControlador : ControllerBase
    {
        private readonly IUsuarioPermisoServicio _usuarioPermisoServicio;

        public UsuarioPermisoControlador(IUsuarioPermisoServicio usuarioPermisoServicio)
        {
            _usuarioPermisoServicio = usuarioPermisoServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioPermisoDto>> ObtenerTodos()
        {
            return await _usuarioPermisoServicio.ObtenerUsuarioPermisosAsync();
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioPermisoDto dto)
        {
            await _usuarioPermisoServicio.CrearUsuarioPermisoAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            await _usuarioPermisoServicio.DesactivarUsuarioPermisoAsync(id);
            return Ok();
        }
    }
}
