using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplicacion.DTOs;
using Aplicacion.Interfaces.IServicios;
using Aplicacion.Interfaces;
using Aplicacion.Interfaces.Servicios;
using System.IdentityModel.Tokens.Jwt;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class AuthServicio : IAuthServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ICargoRepositorio _cargoRepositorio;
        private readonly ITokenServicio _tokenServicio;
        private readonly HttpClient _httpClient;

        public AuthServicio(IUsuarioRepositorio usuarioRepositorio, ICargoRepositorio cargoRepositorio, ITokenServicio tokenServicio, HttpClient httpClient)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _cargoRepositorio = cargoRepositorio;
            _tokenServicio = tokenServicio;
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // 🔹 1. Simulación del servicio externo de autenticación
            var fakeToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDb2RpZ29BZ2VuZGEiOiJVMDAxIiwidXNlcm5hbWUiOiJqLnBlcmV6Iiwibm9tYnJlIjoiSnVhbiBQZXJleiIsImVtYWlsIjoianVhbi5wZXJlekBlbWFpbC5jb20iLCJjYXJnbyI6IkdFUkVOVEUgTkFDSU9OQUwgREUgVEkifQ.CJM8tld4A32I8V5LYnge0tO_7l8QdPUlZTZBJSko95Y";
            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(fakeToken);

            var claims = jwtToken.Claims.ToDictionary(c => c.Type, c => c.Value);
            Console.WriteLine("📢 Claims extraídos del JWT:");
            foreach (var claim in claims)
            {
                Console.WriteLine($"🔹 {claim.Key}: {claim.Value}");
            }

            // ✅ Validar que CodigoAgenda no sea null
            if (!claims.ContainsKey("CodigoAgenda") || string.IsNullOrEmpty(claims["CodigoAgenda"]))
            {
                throw new Exception("El token JWT no contiene el campo 'CodigoAgenda' o está vacío.");
            }

            var codigoAgenda = claims["CodigoAgenda"];
            var nombre = claims.ContainsKey("nombre") ? claims["nombre"] : throw new Exception("El token no tiene el campo 'nombre'.");
            var email = claims.ContainsKey("email") ? claims["email"] : throw new Exception("El token no tiene el campo 'email'.");
            var cargoNombre = claims.ContainsKey("cargo") ? claims["cargo"] : throw new Exception("El token no tiene el campo 'cargo'.");

            Console.WriteLine($"✅ Código Agenda recibido del JWT: {codigoAgenda}");

            // 🔹 2. Verificar si el usuario existe en la BDD
            var usuario = await _usuarioRepositorio.ObtenerPorCodigoAgendaAsync(codigoAgenda);

            if (usuario == null)
            {
                Console.WriteLine("⚠ Usuario no encontrado en la base de datos. Registrando...");

                // 🔹 3. Verificar si el cargo existe
                var cargoId = await _cargoRepositorio.ObtenerIdPorNombreAsync(cargoNombre);
                if (cargoId == null)
                    throw new Exception("Cargo no autorizado");

                // 🔹 4. Registrar usuario y asignarle el cargo
                var nuevoUsuario = new UsuarioDto
                {
                    CodAgenda = codigoAgenda,
                    Username = claims["username"],
                    Nombre = nombre,
                    Email = email
                };

                await _usuarioRepositorio.GuardarUsuarioAsync(nuevoUsuario);

                usuario = nuevoUsuario;
            }

            // 🔹 5. Generar token interno
            var tokenInterno = _tokenServicio.GenerarToken(usuario);
            return tokenInterno;
        }


    }

}
