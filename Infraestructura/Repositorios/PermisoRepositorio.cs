using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dapper;
using Dominio.Entidades;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class PermisoRepositorio : DapperRepository, IPermisoRepositorio
    {
        public PermisoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<PermisoDTO>> ObtenerTodosAsync()
        {
            using var connection = Connection;
            return await connection.QueryAsync<PermisoDTO>("sp_ObtenerPermisos", commandType: CommandType.StoredProcedure);
        }

        public async Task<PermisoDTO> ObtenerPorIdAsync(int id)
        {
            using var connection = Connection;
            return await connection.QueryFirstOrDefaultAsync<PermisoDTO>(
                "sp_ObtenerPermisoPorId",
                new { PermisoId= id },
                commandType: CommandType.StoredProcedure);
        }

        public async Task AgregarAsync(PermisoDTO dto)
        {
            using var connection = Connection;
            await connection.ExecuteAsync(
                "sp_AgregarPermiso",
                new { dto.Descripcion, dto.CreadoPor },
                commandType: CommandType.StoredProcedure);
        }

        public async Task ModificarAsync(PermisoDTO dto)
        {
            using var connection = Connection;
            await connection.ExecuteAsync(
                "sp_ModificarPermiso",
                new { PermisoId= dto.PermisoId, Descripcion= dto.Descripcion },
                commandType: CommandType.StoredProcedure);
        }

        public async Task DesactivarAsync(int id)
        {
            using var connection = Connection;
            await connection.ExecuteAsync("sp_DesactivarPermiso", new { PermisoId = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
