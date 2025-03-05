using Aplicacion.Interfaces.IServicios;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.DTOs;

namespace API.Controladores
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServicio _authServicio;

        public AuthController(IAuthServicio authServicio)
        {
            _authServicio = authServicio;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authServicio.LoginAsync(request.Username, request.Password);
            return Ok(new { Token = token });
        }
    }

}
