using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<Usuario> ObtenerUsuarioPorCodAgendaAsync(string codAgenda);
        Task<IEnumerable<Usuario>> ObtenerUsuariosActivosAsync();
        Task CrearUsuarioAsync(Usuario usuario);  // ✅ Método requerido
    }
}
