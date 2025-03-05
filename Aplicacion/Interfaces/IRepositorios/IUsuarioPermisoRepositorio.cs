using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces.IRepositorios
{
    public interface IUsuarioPermisoRepositorio
    {
        Task<IEnumerable<UsuarioPermisoDTO>> ObtenerPermisosPorUsuarioAsync(string usuarioCodAgenda);
        Task ActualizarPermisoUsuarioAsync(string usuarioCodAgenda, List<UsuarioPermisoDTO> permisos, string modificadoPor);
    }
}
