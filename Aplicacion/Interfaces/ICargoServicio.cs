using Aplicacion.DTOs;


namespace Aplicacion.Interfaces
{
    public interface ICargoServicio
    {
        Task<IEnumerable<CargoDto>> ObtenerCargosAsync();
        Task CrearCargoAsync(CargoDto cargoDto);
        Task ModificarCargoAsync(int id, CargoDto cargoDto);
        Task DesactivarCargoAsync(int id);
    }
}
