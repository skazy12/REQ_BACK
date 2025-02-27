using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [Route("api/permisos")]
    [ApiController]
    public class PermisoControlador : ControllerBase
    {
        private readonly IPermisoServicio _servicio;

        public PermisoControlador(IPermisoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            return Ok(await _servicio.ObtenerTodosAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var permiso = await _servicio.ObtenerPorIdAsync(id);

            if (permiso == null)
                return NotFound($"No se encontró un permiso con ID {id}"); //arroja 404

            return Ok(permiso);
        }


        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] PermisoDTO dto)
        {
            // Crear el permiso sin ID (será generado por la BD)
            var permiso = new PermisoDTO
            {
                Descripcion = dto.Descripcion,
                Activo = true
            };

            await _servicio.AgregarAsync(permiso);

            // Volver a obtener el permiso para recuperar su ID
            var permisos = await _servicio.ObtenerTodosAsync();
            var nuevoPermiso = permisos.LastOrDefault(p => p.Descripcion == dto.Descripcion);

            if (nuevoPermiso == null)
                return BadRequest("No se pudo recuperar el permiso recién creado.");

            return CreatedAtAction(nameof(ObtenerPorId), new { id = nuevoPermiso.PermisoId }, nuevoPermiso);
        }


        [HttpPut]
        public async Task<IActionResult> Modificar([FromBody] PermisoDTO dto)
        {
            await _servicio.ModificarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            await _servicio.DesactivarAsync(id);
            return NoContent();
        }
    }
}
