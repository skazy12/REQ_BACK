using Aplicacion.DTOs;


namespace Aplicacion.Interfaces
{
    public interface IUsuarioPermisoServicio
    {
        Task<IEnumerable<UsuarioPermisoDto>> ObtenerUsuarioPermisosAsync();
        Task<UsuarioPermisoDto> ObtenerUsuarioPermisoPorIdAsync(int id);
        Task CrearUsuarioPermisoAsync(UsuarioPermisoDto usuarioPermisoDto);
        Task ModificarUsuarioPermisoAsync(int id, UsuarioPermisoDto usuarioPermisoDto);
        Task DesactivarUsuarioPermisoAsync(int id);
    }
}
