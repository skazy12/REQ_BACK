// Archivo: API/Controladores/CargoPermisoControlador.cs
using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Aplicacion.Servicios;
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
        public async Task<IActionResult> ObtenerPermisosActivosPorCargo(int cargoId)
        {
            return Ok(await _servicio.ObtenerPermisosActivosPorCargoAsync(cargoId));
        }

        [HttpPost]
        public async Task<IActionResult> ActualizarPermisosCargo([FromBody] CargoPermisoDTO dto)
        {
            await _servicio.ActualizarPermisosCargoAsync(dto);
            return Ok();
        }
    }
}
