using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controladores
{
    [ApiController]
    [Route("api/cargos")]
    public class CargoControlador : ControllerBase
    {
        private readonly ICargoServicio _cargoServicio;

        public CargoControlador(ICargoServicio cargoServicio)
        {
            _cargoServicio = cargoServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<CargoDto>> ObtenerCargos()
        {
            return await _cargoServicio.ObtenerCargosAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCargo([FromBody] CargoDto cargoDto)
        {
            await _cargoServicio.CrearCargoAsync(cargoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarCargo(int id, [FromBody] CargoDto cargoDto)
        {
            await _cargoServicio.ModificarCargoAsync(id, cargoDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesactivarCargo(int id)
        {
            await _cargoServicio.DesactivarCargoAsync(id);
            return Ok();
        }
    }
}
