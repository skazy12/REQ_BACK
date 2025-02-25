using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controladores
{
    [ApiController]
    [Route("api/usuarios-sp")]
    public class UsuarioControladorSP : ControllerBase
    {
        private readonly IUsuarioServicio _usuarioServicio;

        public UsuarioControladorSP(IUsuarioServicio usuarioServicio)
        {
            _usuarioServicio = usuarioServicio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerUsuariosConCargosYPermisosSP()
        {
            var usuariosDetalles = await _usuarioServicio.ObtenerUsuariosConCargosYPermisosDesdeSPAsync();

            if (usuariosDetalles == null || usuariosDetalles.Count == 0)
            {
                return NotFound("No se encontraron usuarios.");
            }

            return Ok(usuariosDetalles);
        }
    }
}
