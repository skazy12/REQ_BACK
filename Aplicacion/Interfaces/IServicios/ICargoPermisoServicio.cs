// Archivo: Aplicacion/Interfaces/ICargoPermisoServicio.cs
using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ICargoPermisoServicio
    {
        Task<IEnumerable<PermisoDTO>> ObtenerPermisosPorCargoAsync(int cargoId);
        Task ActualizarPermisosCargoAsync(CargoPermisoDTO dto);
    }
}
