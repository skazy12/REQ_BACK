using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class CargoPermisoRepositorio : DapperRepository, ICargoPermisoRepositorio
    {
        public CargoPermisoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<PermisoDTO>> ObtenerPermisosPorCargoAsync(int cargoId)
        {
            using var connection = Connection;
            return await connection.QueryAsync<PermisoDTO>(
                "sp_ObtenerPermisosPorCargo",
                new { cargoId },
                commandType: CommandType.StoredProcedure);
        }

        public async Task ActualizarPermisosCargoAsync(CargoPermisoDTO dto)
        {
            using var connection = Connection;
            foreach (var permiso in dto.Permisos)
            {
                await connection.ExecuteAsync(
                    "sp_ActualizarPermisosCargo",
                    new { dto.CargoId, permiso.PermisoId, permiso.Asignado, permiso.ModificadoPor },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
