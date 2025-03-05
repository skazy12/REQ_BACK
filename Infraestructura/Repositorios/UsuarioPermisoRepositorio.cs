using Aplicacion.DTOs;
using Aplicacion.Excepciones;
using Aplicacion.Interfaces.IRepositorios;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class UsuarioPermisoRepositorio : DapperRepository, IUsuarioPermisoRepositorio
    {
        public UsuarioPermisoRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<UsuarioPermisoDTO>> ObtenerPermisosPorUsuarioAsync(string usuarioCodAgenda)
        {
            using var connection = Connection;
            var parametros = new { UsuarioCodAgenda = usuarioCodAgenda };

            var permisos = await connection.QueryAsync<UsuarioPermisoDTO>(
                "sp_ObtenerPermisosPorUsuario",
                parametros,
                commandType: CommandType.StoredProcedure
            );

            if (permisos == null)
                throw new ExcepcionNoEncontrado($"No se encontraron permisos para el usuario {usuarioCodAgenda}");

            return permisos;
        }

        public async Task ActualizarPermisoUsuarioAsync(string usuarioCodAgenda, List<UsuarioPermisoDTO> permisos, string modificadoPor)
        {
            using var connection = Connection;
            var dataTable = new DataTable();
            dataTable.Columns.Add("PermisoId", typeof(int));
            dataTable.Columns.Add("Asignado", typeof(bool));

            foreach (var permiso in permisos)
            {
                dataTable.Rows.Add(permiso.PermisoId, permiso.Asignado);
            }

            var parametros = new
            {
                UsuarioCodAgenda = usuarioCodAgenda,
                Permisos = dataTable.AsTableValuedParameter("PermisoTipo"),
                ModificadoPor = modificadoPor
            };

            try
            {
                await connection.ExecuteAsync(
                    "sp_ActualizarPermisosUsuario",
                    parametros,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch (SqlException ex)
            {
                throw new ExcepcionNegocio($"Error al actualizar permisos: {ex.Message}");
            }
        }
    }
}
