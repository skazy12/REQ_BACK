using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioServicio
    {

        Task<UsuarioDto> ObtenerUsuarioPorCodAgendaAsync(string codAgenda);

        Task<IEnumerable<UsuarioDto>> ObtenerUsuariosActivosAsync();

        Task CrearUsuarioAsync(UsuarioDto usuarioDto);
    }
}
