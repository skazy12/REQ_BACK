
using Aplicacion.DTOs;


namespace Aplicacion.Interfaces
{
    public interface IJerarquiaCargosServicio
    {
        Task<IEnumerable<JerarquiaCargosDto>> ObtenerJerarquiasAsync();
        Task CrearJerarquiaAsync(JerarquiaCargosDto jerarquiaDto, string usuarioCodAgenda);
        Task ModificarJerarquiaAsync(int id, JerarquiaCargosDto jerarquiaDto, string usuarioCodAgenda);
        Task DesactivarJerarquiaAsync(int id, string usuarioCodAgenda);
        Task<IEnumerable<int>> ObtenerCargosSuperioresAsync(int cargoId);
    }
}
