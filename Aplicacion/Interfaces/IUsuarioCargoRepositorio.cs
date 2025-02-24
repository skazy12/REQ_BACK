using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioCargoRepositorio
    {
        Task<IEnumerable<UsuarioCargo>> ObtenerTodosAsync();
        Task<UsuarioCargo> ObtenerPorIdAsync(int id);
        Task CrearAsync(UsuarioCargo usuarioCargo);
        Task ModificarAsync(int id, UsuarioCargo usuarioCargo);
        Task DesactivarAsync(int id);
    }
}
