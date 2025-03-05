using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioServicio
    {
        Task<IEnumerable<UsuarioConPermisoYCargoDTO>> ObtenerUsuariosConPermisosYCargosAsync();
    }
}
