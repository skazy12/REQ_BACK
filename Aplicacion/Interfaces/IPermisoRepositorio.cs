using Dominio.Entidades;
namespace Aplicacion.Interfaces
{
    public interface IPermisoRepositorio
    {
        Task<IEnumerable<Permiso>> ObtenerTodosAsync();
        Task<Permiso> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Permiso permiso);
        Task ModificarAsync(Permiso permiso);
        Task DesactivarAsync(int id);
    }
}
