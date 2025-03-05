using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Aplicacion.DTOs.UsuarioCargoDTO;

namespace Aplicacion.Servicios
{
    public class UsuarioCargoServicio : IUsuarioCargoServicio
    {
        private readonly IUsuarioCargoRepositorio _usuarioCargoRepositorio;

        public UsuarioCargoServicio(IUsuarioCargoRepositorio usuarioCargoRepositorio)
        {
            _usuarioCargoRepositorio = usuarioCargoRepositorio;
        }

        /// 🔍 Obtiene todos los cargos y si están asignados al usuario
        public async Task<IEnumerable<UsuarioCargoListadoDTO>> ObtenerCargosPorUsuarioAsync(string usuarioCodAgenda)
        {
            return await _usuarioCargoRepositorio.ObtenerCargosPorUsuarioAsync(usuarioCodAgenda);
        }

        /// 💾 Actualiza los cargos asignados al usuario
        public async Task ActualizarCargosUsuarioAsync(UsuarioCargoUpdateDTO dto)
        {
            dto.ModificadoPor = "admin";
            await _usuarioCargoRepositorio.ActualizarCargosUsuarioAsync(dto);
        }
    }
}
