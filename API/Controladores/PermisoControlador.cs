using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace API.Controladores
{
    [ApiController]
    [Route("api/permisos")]
    public class PermisoControlador : ControllerBase
    {
        private readonly IPermisoServicio _permisoServicio;

        public PermisoControlador(IPermisoServicio permisoServicio)
        {
            _permisoServicio = permisoServicio;
        }

        [HttpGet]
        public async Task<IEnumerable<PermisoDto>> ObtenerPermisos()
        {
            return await _permisoServicio.ObtenerPermisosAsync();
        }

        [HttpPost]
        public async Task<IActionResult> CrearPermiso([FromBody] PermisoDto permisoDto)
        {
            await _permisoServicio.CrearPermisoAsync(permisoDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModificarPermiso(int id, [FromBody] PermisoDto permisoDto)
        {
            await _permisoServicio.ModificarPermisoAsync(id, permisoDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesactivarPermiso(int id)
        {
            await _permisoServicio.DesactivarPermisoAsync(id);
            return Ok();
        }
    }
}
