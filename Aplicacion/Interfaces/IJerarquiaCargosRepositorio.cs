using Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Interfaces
{
    public interface IJerarquiaCargosRepositorio
    {
        Task<IEnumerable<JerarquiaCargos>> ObtenerJerarquiasAsync();
        Task CrearJerarquiaAsync(JerarquiaCargos jerarquia);
        Task ModificarJerarquiaAsync(int id, JerarquiaCargos jerarquia);
        Task DesactivarJerarquiaAsync(int id);
        Task<IEnumerable<int>> ObtenerCargosSuperioresAsync(int cargoId);
        Task<IEnumerable<int>> ObtenerCargosInferioresAsync(int cargoId);
    }
}
