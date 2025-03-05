using Aplicacion.DTOs;


namespace Aplicacion.Interfaces
{
    public interface ICargoRepositorio
    {
        Task<IEnumerable<CargoDTO>> ObtenerTodosAsync();
        Task<CargoDTO> ObtenerPorIdAsync(int id);
        Task<int> AgregarAsync(CargoDTO cargo);
        Task<int> ModificarAsync(CargoDTO dto);
        Task DesactivarAsync(int id);

        Task<int?> ObtenerIdPorNombreAsync(string nombre);
    }
}
