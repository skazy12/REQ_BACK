// Archivo: API/Controladores/CargoPermisoControlador.cs
using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [Route("api/cargos/permisos")]
    [ApiController]
    public class CargoPermisoControlador : ControllerBase
    {
        private readonly ICargoPermisoServicio _servicio;

        public CargoPermisoControlador(ICargoPermisoServicio servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("{cargoId}")]
        public async Task<IActionResult> ObtenerPermisosPorCargo(int cargoId)
        {
            return Ok(await _servicio.ObtenerPermisosPorCargoAsync(cargoId));
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarPermisosCargo([FromBody] CargoPermisoDTO dto)
        {
            await _servicio.ActualizarPermisosCargoAsync(dto);
            return Ok();
        }
    }
}
