using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class UsuarioPermisoServicio : IUsuarioPermisoServicio
    {
        private readonly IUsuarioPermisoRepositorio _usuarioPermisoRepositorio;

        public UsuarioPermisoServicio(IUsuarioPermisoRepositorio usuarioPermisoRepositorio)
        {
            _usuarioPermisoRepositorio = usuarioPermisoRepositorio;
        }

        public async Task<IEnumerable<UsuarioPermisoDto>> ObtenerUsuarioPermisosAsync()
        {
            var usuarioPermisos = await _usuarioPermisoRepositorio.ObtenerUsuarioPermisosAsync();
            return usuarioPermisos.Select(up => new UsuarioPermisoDto
            {
                UsuarioPermisoId = up.UsuarioPermisoId,
                UsuarioCodAgenda = up.UsuarioCodAgenda,
                PermisoId = up.PermisoId,
                ModificadoPor = up.ModificadoPor
            });
        }

        public async Task<UsuarioPermisoDto> ObtenerUsuarioPermisoPorIdAsync(int id)
        {
            var usuarioPermiso = await _usuarioPermisoRepositorio.ObtenerUsuarioPermisoPorIdAsync(id);
            if (usuarioPermiso == null) return null;

            return new UsuarioPermisoDto
            {
                UsuarioPermisoId = usuarioPermiso.UsuarioPermisoId,
                UsuarioCodAgenda = usuarioPermiso.UsuarioCodAgenda,
                PermisoId = usuarioPermiso.PermisoId,
                ModificadoPor = usuarioPermiso.ModificadoPor
            };
        }

        public async Task CrearUsuarioPermisoAsync(UsuarioPermisoDto usuarioPermisoDto)
        {
            var usuarioPermiso = new UsuarioPermiso
            {
                UsuarioCodAgenda = usuarioPermisoDto.UsuarioCodAgenda,
                PermisoId = usuarioPermisoDto.PermisoId,
                ModificadoPor = usuarioPermisoDto.ModificadoPor
            };

            await _usuarioPermisoRepositorio.CrearUsuarioPermisoAsync(usuarioPermiso);
        }

        public async Task ModificarUsuarioPermisoAsync(int id, UsuarioPermisoDto usuarioPermisoDto)
        {
            var usuarioPermiso = new UsuarioPermiso
            {
                UsuarioPermisoId = id,
                UsuarioCodAgenda = usuarioPermisoDto.UsuarioCodAgenda,
                PermisoId = usuarioPermisoDto.PermisoId,
                ModificadoPor = usuarioPermisoDto.ModificadoPor
            };

            await _usuarioPermisoRepositorio.ModificarUsuarioPermisoAsync(id, usuarioPermiso);
        }

        public async Task DesactivarUsuarioPermisoAsync(int id)
        {
            await _usuarioPermisoRepositorio.DesactivarUsuarioPermisoAsync(id);
        }
    }
}
