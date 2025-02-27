
using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface ICargoRepositorio
    {
        Task<IEnumerable<Cargo>> ObtenerTodosAsync();
        Task<Cargo> ObtenerPorIdAsync(int id);
        Task AgregarAsync(Cargo cargo);
        Task ModificarAsync(Cargo cargo);
        Task DesactivarAsync(int id);
    }
}
