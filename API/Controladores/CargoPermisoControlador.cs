using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controladores
{
    [ApiController]
    [Route("api/cargo-permisos")]
    public class CargoPermisoControlador : ControllerBase
    {
        private readonly ICargoPermisoServicio _cargoPermisoServicio;

        public CargoPermisoControlador(ICargoPermisoServicio cargoPermisoServicio)
        {
            _cargoPermisoServicio = cargoPermisoServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<CargoPermisoDto>> ObtenerTodos()
        {
            return await _cargoPermisoServicio.ObtenerCargoPermisosAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cargoPermiso = await _cargoPermisoServicio.ObtenerCargoPermisoPorIdAsync(id);
            if (cargoPermiso == null) return NotFound();
            return Ok(cargoPermiso);
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CargoPermisoDto dto)
        {
            await _cargoPermisoServicio.CrearCargoPermisoAsync(dto);
            return Ok(new { mensaje = "Cargo-Permiso creado exitosamente." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modificar(int id, [FromBody] CargoPermisoDto dto)
        {
            await _cargoPermisoServicio.ModificarCargoPermisoAsync(id, dto);
            return Ok(new { mensaje = "Cargo-Permiso modificado exitosamente." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Desactivar(int id)
        {
            await _cargoPermisoServicio.DesactivarCargoPermisoAsync(id);
            return Ok(new { mensaje = "Cargo-Permiso desactivado exitosamente." });
        }
    }
}
