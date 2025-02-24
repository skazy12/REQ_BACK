using Dominio.Entidades;
namespace Aplicacion.Interfaces
{
    public interface IPermisoRepositorio
    {
        Task<IEnumerable<Permiso>> ObtenerPermisosAsync();
        Task CrearPermisoAsync(Permiso permiso);
        Task ModificarPermisoAsync(int id, Permiso permiso);
        Task DesactivarPermisoAsync(int id);
    }
}
