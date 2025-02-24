using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioPermisoRepositorio
    {
        Task<IEnumerable<UsuarioPermiso>> ObtenerUsuarioPermisosAsync();
        Task<UsuarioPermiso> ObtenerUsuarioPermisoPorIdAsync(int id);
        Task CrearUsuarioPermisoAsync(UsuarioPermiso usuarioPermiso);
        Task ModificarUsuarioPermisoAsync(int id, UsuarioPermiso usuarioPermiso);
        Task DesactivarUsuarioPermisoAsync(int id);
    }
}
