using Aplicacion.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Aplicacion.DTOs.UsuarioCargoDTO;

namespace Aplicacion.Interfaces
{
    public interface IUsuarioCargoServicio
    {
        Task<IEnumerable<UsuarioCargoListadoDTO>> ObtenerCargosPorUsuarioAsync(string usuarioCodAgenda);

        /// 📝 **Actualiza los cargos asignados al usuario**
        Task ActualizarCargosUsuarioAsync(UsuarioCargoUpdateDTO dto);
    }
}
