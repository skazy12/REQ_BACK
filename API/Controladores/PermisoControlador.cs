using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controladores
{
    [Route("api/permisos")]
    [ApiController]
    public class PermisoControlador : ControllerBase
    {
        private readonly IPermisoServicio _permisoServicio;

        public PermisoControlador(IPermisoServicio permisoServicio)
        {
            _permisoServicio = permisoServicio;
        }

        /// <summary>
        /// Obtiene todos los permisos activos.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerPermisos()
        {
            var permisos = await _permisoServicio.ObtenerTodosAsync();
            return Ok(permisos);
        }

        /// <summary>
        /// Obtiene un permiso por su ID.
        /// </summary>
        [HttpGet("{permisoId}")]
        public async Task<IActionResult> ObtenerPermisoPorId(int permisoId)
        {
            var permiso = await _permisoServicio.ObtenerPorIdAsync(permisoId);
            if (permiso == null)
                return NotFound($"No se encontró el permiso con ID {permisoId}.");

            return Ok(permiso);
        }

        
        [HttpPost]
        public async Task<IActionResult> AgregarPermiso([FromBody] PermisoDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Descripcion))
                return BadRequest("La descripción del permiso es obligatoria.");

            dto.CreadoPor = "admin"; // Usuario de prueba hasta implementar autenticación

            await _permisoServicio.AgregarAsync(dto);
            return CreatedAtAction(nameof(ObtenerPermisoPorId), new { permisoId = dto.PermisoId }, dto);
        }

        
        [HttpPut("{permisoId}")]
        public async Task<IActionResult> ModificarPermiso(int permisoId, [FromBody] PermisoDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Descripcion))
                return BadRequest("La descripción del permiso es obligatoria.");

            dto.PermisoId = permisoId;
            await _permisoServicio.ModificarAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Desactiva un permiso por su ID.
        /// </summary>
        [HttpDelete("{permisoId}")]
        public async Task<IActionResult> DesactivarPermiso(int permisoId)
        {
            await _permisoServicio.DesactivarAsync(permisoId);
            return NoContent();
        }
    }
}
