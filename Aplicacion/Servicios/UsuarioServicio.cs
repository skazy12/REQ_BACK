using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<UsuarioDto> ObtenerUsuarioPorCodAgendaAsync(string codAgenda)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCodAgendaAsync(codAgenda);
            if (usuario == null) return null;

            return new UsuarioDto
            {
                CodAgenda = usuario.CodAgenda,
                Username = usuario.Username,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Activo = usuario.Activo,
                Cargos = usuario.UsuarioCargos.Select(uc => uc.Cargo.Nombre).ToList()
            };
        }

        public async Task<IEnumerable<UsuarioDto>> ObtenerUsuariosActivosAsync() // ✅ Implementación del método faltante
        {
            var usuarios = await _usuarioRepositorio.ObtenerUsuariosActivosAsync();
            return usuarios.Select(usuario => new UsuarioDto
            {
                CodAgenda = usuario.CodAgenda,
                Username = usuario.Username,
                Nombre = usuario.Nombre,
                Correo = usuario.Correo,
                Activo = usuario.Activo,
                Cargos = usuario.UsuarioCargos.Select(uc => uc.Cargo.Nombre).ToList()
            });
        }

        public async Task CrearUsuarioAsync(UsuarioDto usuarioDto)
        {
            var usuario = new Usuario
            {
                CodAgenda = usuarioDto.CodAgenda,
                Username = usuarioDto.Username,
                Nombre = usuarioDto.Nombre,
                Correo = usuarioDto.Correo,
                Activo = true
            };

            await _usuarioRepositorio.CrearUsuarioAsync(usuario);
        }
        public async Task<List<UsuarioDetallesDto>> ObtenerUsuariosConCargosYPermisosDesdeSPAsync()
        {
            return await _usuarioRepositorio.ObtenerUsuariosConCargosYPermisosDesdeSPAsync();
        }
    }
}
