using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioControlador : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioControlador(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet("{codAgenda}")]
        public async Task<IActionResult> ObtenerUsuario(string codAgenda)
        {
            var usuario = await _usuarioServicio.ObtenerUsuarioPorCodAgendaAsync(codAgenda);
            if (usuario == null) return NotFound("Usuario no encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioDto usuarioDto)
        {
            await _usuarioServicio.CrearUsuarioAsync(usuarioDto);
            return Ok("Usuario creado exitosamente.");
        }

        [HttpGet("activos")]
        public async Task<IActionResult> ObtenerUsuariosActivos()
        {
            var usuarios = await _usuarioServicio.ObtenerUsuariosActivosAsync();
            return Ok(usuarios);
        }
    }
}
