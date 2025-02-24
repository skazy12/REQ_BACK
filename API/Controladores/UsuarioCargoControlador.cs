using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controladores
{
    [ApiController]
    [Route("api/usuario-cargos")]
    public class UsuarioCargoControlador : ControllerBase
    {
        private readonly IUsuarioCargoServicio _usuarioCargoServicio;

        public UsuarioCargoControlador(IUsuarioCargoServicio usuarioCargoServicio)
        {
            _usuarioCargoServicio = usuarioCargoServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<UsuarioCargoDto>> ObtenerTodos()
        {
            return await _usuarioCargoServicio.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var usuarioCargo = await _usuarioCargoServicio.ObtenerPorIdAsync(id);
            if (usuarioCargo == null) return NotFound();
            return Ok(usuarioCargo);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuarioCargoDto dto)
        {
            await _usuarioCargoServicio.CrearAsync(dto);
            return Ok(new { mensaje = "Usuario-Cargo asignado exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] UsuarioCargoDto dto)
        {
            await _usuarioCargoServicio.ModificarAsync(id, dto);
            return Ok(new { mensaje = "Usuario-Cargo modificado exitosamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            await _usuarioCargoServicio.DesactivarAsync(id);
            return Ok(new { mensaje = "Usuario-Cargo desactivado exitosamente." });
        }
    }
}
