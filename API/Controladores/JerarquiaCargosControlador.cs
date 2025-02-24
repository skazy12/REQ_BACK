using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controladores
{
    [ApiController]
    [Route("api/jerarquia-cargos")]
    public class JerarquiaCargosControlador : ControllerBase
    {
        private readonly IJerarquiaCargosServicio _jerarquiaCargosServicio;

        public JerarquiaCargosControlador(IJerarquiaCargosServicio jerarquiaCargosServicio)
        {
            _jerarquiaCargosServicio = jerarquiaCargosServicio;
        }

        /// <summary>
        /// Obtiene todas las jerarquías de cargos.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var jerarquias = await _jerarquiaCargosServicio.ObtenerJerarquiasAsync();
            return Ok(jerarquias);
        }

        /// <summary>
        /// Crea una nueva jerarquía de cargos.
        /// </summary>
        /// <param name="dto">DTO con los datos de la jerarquía.</param>
        /// <param name="usuarioCodAgenda">Código del usuario que realiza la modificación.</param>
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] JerarquiaCargosDto dto, [FromQuery] string usuarioCodAgenda)
        {
            if (string.IsNullOrEmpty(usuarioCodAgenda))
                return BadRequest("El usuario que realiza la modificación es requerido.");

            await _jerarquiaCargosServicio.CrearJerarquiaAsync(dto, usuarioCodAgenda);
            return Ok(new { mensaje = "Jerarquía de cargos creada exitosamente." });
        }

        /// <summary>
        /// Modifica una jerarquía de cargos existente.
        /// </summary>
        /// <param name="id">ID de la jerarquía a modificar.</param>
        /// <param name="dto">DTO con los datos actualizados.</param>
        /// <param name="usuarioCodAgenda">Código del usuario que realiza la modificación.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] JerarquiaCargosDto dto, [FromQuery] string usuarioCodAgenda)
        {
            if (string.IsNullOrEmpty(usuarioCodAgenda))
                return BadRequest("El usuario que realiza la modificación es requerido.");

            await _jerarquiaCargosServicio.ModificarJerarquiaAsync(id, dto, usuarioCodAgenda);
            return Ok(new { mensaje = "Jerarquía de cargos modificada exitosamente." });
        }

        /// <summary>
        /// Desactiva una jerarquía de cargos (equivalente a eliminar).
        /// </summary>
        /// <param name="id">ID de la jerarquía a desactivar.</param>
        /// <param name="usuarioCodAgenda">Código del usuario que realiza la modificación.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id, [FromQuery] string usuarioCodAgenda)
        {
            if (string.IsNullOrEmpty(usuarioCodAgenda))
                return BadRequest("El usuario que realiza la modificación es requerido.");

            await _jerarquiaCargosServicio.DesactivarJerarquiaAsync(id, usuarioCodAgenda);
            return Ok(new { mensaje = "Jerarquía de cargos desactivada exitosamente." });
        }

        /// <summary>
        /// Obtiene los cargos superiores de un cargo dado.
        /// </summary>
        /// <param name="cargoId">ID del cargo a consultar.</param>
        [HttpGet("superiores/{cargoId}")]
        public async Task<IActionResult> ObtenerCargosSuperiores(int cargoId)
        {
            var cargosSuperiores = await _jerarquiaCargosServicio.ObtenerCargosSuperioresAsync(cargoId);
            return Ok(cargosSuperiores);
        }
    }
}
