// Archivo: Aplicacion/Interfaces/ICargoPermisoRepositorio.cs
using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface ICargoPermisoRepositorio
    {
     
        Task<IEnumerable<Permiso>> ObtenerPermisosActivosPorCargoAsync(int cargoId);

        
        Task ActualizarPermisoCargoAsync(int cargoId, int permisoId, bool asignado, string modificadoPor);
    }
}
