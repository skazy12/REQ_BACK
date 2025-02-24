

using Aplicacion.DTOs;
namespace Aplicacion.Interfaces
{
    public interface IPermisoServicio
    {
        Task<IEnumerable<PermisoDto>> ObtenerPermisosAsync();
        Task CrearPermisoAsync(PermisoDto permisoDto);
        Task ModificarPermisoAsync(int id, PermisoDto permisoDto);
        Task DesactivarPermisoAsync(int id);
    }
}
