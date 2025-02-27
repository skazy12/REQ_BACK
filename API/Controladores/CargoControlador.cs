using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [Route("api/cargos")]
    [ApiController]
    public class CargoControlador : ControllerBase
    {
        private readonly ICargoServicio _servicio;

        public CargoControlador(ICargoServicio servicio)
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
            var cargo = await _servicio.ObtenerPorIdAsync(id);
            if (cargo == null)
                return NotFound($"No se encontró un cargo con ID {id}");

            return Ok(cargo);
        }

        [HttpPost]
        public async Task<IActionResult> Agregar([FromBody] CargoDTO dto)
        {
            await _servicio.AgregarAsync(dto);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Modificar([FromBody] CargoDTO dto)
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