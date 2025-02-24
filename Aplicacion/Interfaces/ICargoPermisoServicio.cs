using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ICargoPermisoServicio
    {
        Task<IEnumerable<CargoPermisoDto>> ObtenerCargoPermisosAsync();
        Task<CargoPermisoDto> ObtenerCargoPermisoPorIdAsync(int id);
        Task CrearCargoPermisoAsync(CargoPermisoDto cargoPermisoDto);
        Task ModificarCargoPermisoAsync(int id, CargoPermisoDto cargoPermisoDto);
        Task DesactivarCargoPermisoAsync(int id);
    }
}
