using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServicio(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IEnumerable<UsuarioConPermisoYCargoDTO>> ObtenerUsuariosConPermisosYCargosAsync()
        {
            return await _usuarioRepositorio.ObtenerUsuariosConPermisosYCargosAsync();
        }
    }
}
