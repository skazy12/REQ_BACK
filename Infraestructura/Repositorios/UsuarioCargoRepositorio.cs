using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Aplicacion.DTOs.UsuarioCargoDTO;

namespace Infraestructura.Repositorios
{
    public class UsuarioCargoRepositorio : DapperRepository, IUsuarioCargoRepositorio
    {
        public UsuarioCargoRepositorio(IConfiguration configuration) : base(configuration) { }

        

        public async Task<IEnumerable<UsuarioCargoListadoDTO>> ObtenerCargosPorUsuarioAsync(string usuarioCodAgenda)
        {
            using var connection = Connection;
            var parametros = new { UsuarioCodAgenda = usuarioCodAgenda };
            return await connection.QueryAsync<UsuarioCargoListadoDTO>(
                "sp_ObtenerCargosPorUsuario",
                parametros,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task ActualizarCargosUsuarioAsync(UsuarioCargoUpdateDTO dto)
        {
            using var connection = Connection;
            await connection.ExecuteAsync(
                "sp_ActualizarCargosUsuario",
                new { dto.UsuarioCodAgenda, dto.CargosAsignados, dto.ModificadoPor },
                commandType: CommandType.StoredProcedure);
        }


    }
}
