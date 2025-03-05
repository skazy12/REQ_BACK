using Aplicacion.DTOs;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioConPermisoYCargoDTO>> ObtenerUsuariosConPermisosYCargosAsync();

        Task<UsuarioDto> ObtenerPorCodigoAgendaAsync(string codigoAgenda);

        Task GuardarUsuarioAsync(UsuarioDto usuario);
    }
}
