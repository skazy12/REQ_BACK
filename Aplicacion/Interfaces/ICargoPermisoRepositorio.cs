using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface ICargoPermisoRepositorio
    {
        Task<IEnumerable<CargoPermiso>> ObtenerCargoPermisosAsync();
        Task<CargoPermiso> ObtenerCargoPermisoPorIdAsync(int id);
        Task CrearCargoPermisoAsync(CargoPermiso cargoPermiso);
        Task ModificarCargoPermisoAsync(int id, CargoPermiso cargoPermiso);
        Task DesactivarCargoPermisoAsync(int id);
    }
}
