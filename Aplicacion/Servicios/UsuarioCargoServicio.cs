using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class UsuarioCargoServicio : IUsuarioCargoServicio
    {
        private readonly IUsuarioCargoRepositorio _usuarioCargoRepositorio;

        public UsuarioCargoServicio(IUsuarioCargoRepositorio usuarioCargoRepositorio)
        {
            _usuarioCargoRepositorio = usuarioCargoRepositorio;
        }

        public async Task<IEnumerable<UsuarioCargoDto>> ObtenerTodosAsync()
        {
            var usuarioCargos = await _usuarioCargoRepositorio.ObtenerTodosAsync();
            return usuarioCargos.Select(uc => new UsuarioCargoDto
            {
                UsuarioCargoId = uc.UsuarioCargoId,
                UsuarioCodAgenda = uc.UsuarioCodAgenda,
                CargoId = uc.CargoId,
                AsignadoPor = uc.AsignadoPor,
                FechaAsignacion = uc.FechaAsignacion,
                FechaRemocion = uc.FechaRemocion,
                Activo = uc.Activo
            });
        }

        public async Task<UsuarioCargoDto> ObtenerPorIdAsync(int id)
        {
            var usuarioCargo = await _usuarioCargoRepositorio.ObtenerPorIdAsync(id);
            if (usuarioCargo == null) return null;

            return new UsuarioCargoDto
            {
                UsuarioCargoId = usuarioCargo.UsuarioCargoId,
                UsuarioCodAgenda = usuarioCargo.UsuarioCodAgenda,
                CargoId = usuarioCargo.CargoId,
                AsignadoPor = usuarioCargo.AsignadoPor,
                FechaAsignacion = usuarioCargo.FechaAsignacion,
                FechaRemocion = usuarioCargo.FechaRemocion,
                Activo = usuarioCargo.Activo
            };
        }

        public async Task CrearAsync(UsuarioCargoDto usuarioCargoDto)
        {
            var usuarioCargo = new UsuarioCargo
            {
                UsuarioCodAgenda = usuarioCargoDto.UsuarioCodAgenda,
                CargoId = usuarioCargoDto.CargoId,
                AsignadoPor = usuarioCargoDto.AsignadoPor,
                FechaAsignacion = (DateTime)usuarioCargoDto.FechaAsignacion,
                Activo = true
            };

            await _usuarioCargoRepositorio.CrearAsync(usuarioCargo);
        }

        public async Task ModificarAsync(int id, UsuarioCargoDto usuarioCargoDto)
        {
            var usuarioCargo = new UsuarioCargo
            {
                UsuarioCargoId = id,
                UsuarioCodAgenda = usuarioCargoDto.UsuarioCodAgenda,
                CargoId = usuarioCargoDto.CargoId,
                AsignadoPor = usuarioCargoDto.AsignadoPor,
                FechaAsignacion = (DateTime)usuarioCargoDto.FechaAsignacion,
                FechaRemocion = usuarioCargoDto.FechaRemocion,
                Activo = usuarioCargoDto.Activo
            };

            await _usuarioCargoRepositorio.ModificarAsync(id, usuarioCargo);
        }

        public async Task DesactivarAsync(int id)
        {
            await _usuarioCargoRepositorio.DesactivarAsync(id);
        }
    }
}
