using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class CargoRepositorio : DapperRepository, ICargoRepositorio
    {
        public CargoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<CargoDTO>> ObtenerTodosAsync()
        {
            using var connection = Connection;
            return await connection.QueryAsync<CargoDTO>("sp_ObtenerCargos", commandType: CommandType.StoredProcedure);
        }

        public async Task<CargoDTO> ObtenerPorIdAsync(int id)
        {
            using var connection = Connection;
            return await connection.QueryFirstOrDefaultAsync<CargoDTO>(
                "sp_ObtenerCargoPorId",
                new { Cargoid =id},
                commandType: CommandType.StoredProcedure);
        }

        public async Task<int> AgregarAsync(CargoDTO dto)
        {
            using var connection = Connection;
            return await connection.ExecuteAsync(
                "sp_AgregarCargo",
                new
                {
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion,
                    CreadoPor = dto.CreadoPor
                },
                commandType: CommandType.StoredProcedure);
        }


        public async Task<int> ModificarAsync(CargoDTO dto)
        {
            using var connection = Connection;
            return await connection.ExecuteAsync(
                "sp_ModificarCargo",
                new
                {
                    CargoId = dto.CargoId,  
                    Nombre = dto.Nombre,
                    Descripcion = dto.Descripcion
                },
                commandType: CommandType.StoredProcedure);
        }



        public async Task DesactivarAsync(int id)
        {
            using var connection = Connection;
            await connection.ExecuteAsync("sp_DesactivarCargo", new { CargoId=id }, commandType: CommandType.StoredProcedure);
        }

        public async Task<int?> ObtenerIdPorNombreAsync(string nombre)
        {
            using var connection = Connection;
            var query = "EXEC sp_ObtenerCargoPorNombre @Nombre";
            return await connection.QueryFirstOrDefaultAsync<int?>(query, new { Nombre = nombre });
        }
    }
}
