using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IPermisoServicio
    {
        Task<IEnumerable<PermisoDTO>> ObtenerTodosAsync();
        Task<PermisoDTO> ObtenerPorIdAsync(int id);
        Task AgregarAsync(PermisoDTO dto);
        Task ModificarAsync(PermisoDTO dto);
        Task DesactivarAsync(int id);
    }
}
