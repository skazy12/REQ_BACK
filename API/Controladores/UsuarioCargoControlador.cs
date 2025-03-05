using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Aplicacion.DTOs.UsuarioCargoDTO;

namespace API.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioCargoControlador : ControllerBase
    {
        private readonly IUsuarioCargoServicio _usuarioCargoServicio;

        public UsuarioCargoControlador(IUsuarioCargoServicio usuarioCargoServicio)
        {
            _usuarioCargoServicio = usuarioCargoServicio;
        }

        /// 🔍 **Obtiene todos los cargos y si están asignados a un usuario**
        /// <param name="usuarioCodAgenda">Código único del usuario</param>
        [HttpGet("cargos/{usuarioCodAgenda}")]
        public async Task<ActionResult<IEnumerable<CargoAsignadoDTO>>> ObtenerCargosPorUsuario(string usuarioCodAgenda)
        {
            var cargos = await _usuarioCargoServicio.ObtenerCargosPorUsuarioAsync(usuarioCodAgenda);
            return Ok(cargos);
        }

        /// 💾 **Actualiza los cargos asignados a un usuario**
        /// <param name="dto">DTO con el usuario y los cargos a asignar o remover</param>
        [HttpPost("actualizar-cargos")]
        public async Task<IActionResult> ActualizarCargosUsuario([FromBody] UsuarioCargoUpdateDTO dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.UsuarioCodAgenda))
            {
                return BadRequest("El usuario y los cargos a actualizar son requeridos.");
            }

            await _usuarioCargoServicio.ActualizarCargosUsuarioAsync(dto);
            return NoContent();
        }
    }
}
