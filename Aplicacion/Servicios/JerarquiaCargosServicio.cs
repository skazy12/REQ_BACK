using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class JerarquiaCargosServicio : IJerarquiaCargosServicio
    {
        private readonly IJerarquiaCargosRepositorio _jerarquiaRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public JerarquiaCargosServicio(IJerarquiaCargosRepositorio jerarquiaRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _jerarquiaRepositorio = jerarquiaRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }

        public async Task<IEnumerable<JerarquiaCargosDto>> ObtenerJerarquiasAsync()
        {
            var jerarquias = await _jerarquiaRepositorio.ObtenerJerarquiasAsync();
            return jerarquias.Select(j => new JerarquiaCargosDto
            {
                JerarquiaCargosId = j.JerarquiaCargosId,
                CargoIdAsignado = j.CargoIdAsignado,
                CargoIdInferior = j.CargoIdInferior,
                FechaAsignacion = j.FechaAsignacion,
                Activo = j.Activo,
                ModificadoPor = j.ModificadoPor
            });
        }

        public async Task CrearJerarquiaAsync(JerarquiaCargosDto jerarquiaDto, string usuarioCodAgenda)
        {
            // Validamos que el usuario sea Gerente de TI
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCodAgendaAsync(usuarioCodAgenda);
            if (usuario == null || usuario.CodAgenda != "1234")  // ID 1 = Gerente de TI
            {
                throw new UnauthorizedAccessException("No tienes permisos para modificar la jerarquía.");
            }

            var jerarquia = new JerarquiaCargos
            {
                CargoIdAsignado = jerarquiaDto.CargoIdAsignado,
                CargoIdInferior = jerarquiaDto.CargoIdInferior,
                FechaAsignacion = DateTime.UtcNow,
                Activo = true,
                ModificadoPor = usuarioCodAgenda
            };

            await _jerarquiaRepositorio.CrearJerarquiaAsync(jerarquia);
        }

        public async Task ModificarJerarquiaAsync(int id, JerarquiaCargosDto jerarquiaDto, string usuarioCodAgenda)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCodAgendaAsync(usuarioCodAgenda);
            if (usuario == null || usuario.CodAgenda != "1234")
            {
                throw new UnauthorizedAccessException("No tienes permisos para modificar la jerarquía.");
            }

            var jerarquia = new JerarquiaCargos
            {
                JerarquiaCargosId = id,
                CargoIdAsignado = jerarquiaDto.CargoIdAsignado,
                CargoIdInferior = jerarquiaDto.CargoIdInferior,
                FechaAsignacion = jerarquiaDto.FechaAsignacion,
                Activo = jerarquiaDto.Activo,
                ModificadoPor = usuarioCodAgenda
            };

            await _jerarquiaRepositorio.ModificarJerarquiaAsync(id, jerarquia);
        }

        public async Task DesactivarJerarquiaAsync(int id, string usuarioCodAgenda)
        {
            var usuario = await _usuarioRepositorio.ObtenerUsuarioPorCodAgendaAsync(usuarioCodAgenda);
            if (usuario == null || usuario.CodAgenda != "1234")
            {
                throw new UnauthorizedAccessException("No tienes permisos para modificar la jerarquía.");
            }

            await _jerarquiaRepositorio.DesactivarJerarquiaAsync(id);
        }

        public async Task<IEnumerable<int>> ObtenerCargosSuperioresAsync(int cargoId)
        {
            return await _jerarquiaRepositorio.ObtenerCargosSuperioresAsync(cargoId);
        }
    }
}
