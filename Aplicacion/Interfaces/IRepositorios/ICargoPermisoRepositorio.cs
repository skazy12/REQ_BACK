

using Aplicacion.DTOs;


namespace Aplicacion.Interfaces
{
    public interface ICargoPermisoRepositorio
    {
        Task<IEnumerable<PermisoDTO>> ObtenerPermisosPorCargoAsync(int cargoId);
        Task ActualizarPermisosCargoAsync(CargoPermisoDTO dto);
    }
}
