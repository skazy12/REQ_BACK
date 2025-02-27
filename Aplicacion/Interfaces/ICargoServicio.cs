
using Aplicacion.DTOs;

namespace Aplicacion.Interfaces
{
    public interface ICargoServicio
    {
        Task<IEnumerable<CargoDTO>> ObtenerTodosAsync();
        Task<CargoDTO> ObtenerPorIdAsync(int id);
        Task AgregarAsync(CargoDTO dto);
        Task ModificarAsync(CargoDTO dto);
        Task DesactivarAsync(int id);
    }
}
