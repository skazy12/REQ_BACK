using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Interfaces.Servicios;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Aplicacion.Servicios
{
    public class TokenServicio : ITokenServicio
    {
        private readonly IConfiguration _config;
        private readonly ILogger<TokenServicio> _logger;

        public TokenServicio(IConfiguration config, ILogger<TokenServicio> logger)
        {
            _config = config;
            _logger = logger;
        }

        public string GenerarToken(UsuarioDto usuario)
        {
            _logger.LogInformation("📢 Generando token para usuario:");
            _logger.LogInformation("🔹 CodAgenda: {CodAgenda}", usuario?.CodAgenda);
            _logger.LogInformation("🔹 Username: {Username}", usuario?.Username);
            _logger.LogInformation("🔹 Nombre: {Nombre}", usuario?.Nombre);
            _logger.LogInformation("🔹 Email: {Email}", usuario?.Email);

            // 🔹 FORZAR PAUSA EN DEBUGGER PARA INSPECCIONAR
            

            if (usuario == null)
            {
                _logger.LogError("❌ ERROR: usuario es NULL antes de generar el token.");
                throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo al generar el token.");
            }

            if (string.IsNullOrEmpty(usuario.CodAgenda))
            {
                _logger.LogError("❌ ERROR: CodAgenda es NULL o vacío antes de generar el token.");
                throw new ArgumentNullException(nameof(usuario.CodAgenda), "El Código de Agenda no puede ser nulo o vacío.");
            }

            _logger.LogInformation("📢 Generando token para usuario con CodigoAgenda: {CodAgenda}", usuario.CodAgenda);

            var claims = new List<Claim>
            {
                new Claim("CodigoAgenda", usuario.CodAgenda ?? ""),
                new Claim("username", usuario.Username ?? ""),
                new Claim("nombre", usuario.Nombre ?? ""),
                new Claim("email", usuario.Email ?? ""),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(3),
                signingCredentials: creds
            );

            _logger.LogInformation("✅ Token generado exitosamente.");

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
