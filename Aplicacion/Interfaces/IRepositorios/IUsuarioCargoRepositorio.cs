
using static Aplicacion.DTOs.UsuarioCargoDTO;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioCargoRepositorio
    {
        
        Task<IEnumerable<UsuarioCargoListadoDTO>> ObtenerCargosPorUsuarioAsync(string usuarioCodAgenda);

        
        Task ActualizarCargosUsuarioAsync(UsuarioCargoUpdateDTO dto);
    }
}
