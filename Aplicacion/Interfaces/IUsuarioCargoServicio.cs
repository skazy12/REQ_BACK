using Aplicacion.DTOs;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioCargoServicio
    {
        Task<IEnumerable<UsuarioCargoDto>> ObtenerTodosAsync();
        Task<UsuarioCargoDto> ObtenerPorIdAsync(int id);
        Task CrearAsync(UsuarioCargoDto usuarioCargoDto);
        Task ModificarAsync(int id, UsuarioCargoDto usuarioCargoDto);
        Task DesactivarAsync(int id);
    }
}
