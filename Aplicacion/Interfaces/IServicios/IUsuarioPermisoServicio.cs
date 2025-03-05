using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IServicios
{
    public interface IUsuarioPermisoServicio
    {
        Task<IEnumerable<UsuarioPermisoDTO>> ObtenerPermisosPorUsuarioAsync(string usuarioCodAgenda);
        Task ActualizarPermisoUsuarioAsync(string usuarioCodAgenda, List<UsuarioPermisoDTO> permisos);
    }
}
