using Dominio.Entidades;

namespace Aplicacion.Interfaces
{
    public interface ICargoRepositorio
    {
        Task<IEnumerable<Cargo>> ObtenerCargosAsync();
        Task CrearCargoAsync(Cargo cargo);
        Task ModificarCargoAsync(int id, Cargo cargo);
        Task DesactivarCargoAsync(int id);
    }
}
