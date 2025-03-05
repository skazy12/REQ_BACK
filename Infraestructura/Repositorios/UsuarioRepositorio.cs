using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dapper;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Infraestructura.Repositorios
{
    public class UsuarioRepositorio : DapperRepository, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration) { }

       
        public async Task<IEnumerable<UsuarioConPermisoYCargoDTO>> ObtenerUsuariosConPermisosYCargosAsync()
        {
            using var connection = Connection;
            return await connection.QueryAsync<UsuarioConPermisoYCargoDTO>(
                "sp_ObtenerUsuariosConPermisosYCargos",
                commandType: CommandType.StoredProcedure);
        }



        public async Task<UsuarioDto> ObtenerPorCodigoAgendaAsync(string codigoAgenda)
        {
            if (string.IsNullOrEmpty(codigoAgenda))
            {
                throw new ArgumentNullException(nameof(codigoAgenda), "❌ ERROR: Código de Agenda no puede ser nulo o vacío antes de la consulta a la BD.");
            }

            Console.WriteLine($"📡 Buscando usuario en la BD con CodigoAgenda: {codigoAgenda}");

            using var connection = Connection;
            var query = "EXEC sp_ObtenerUsuarioPorCodigoAgenda @CodigoAgenda";

            var usuario = await connection.QueryFirstOrDefaultAsync<UsuarioDto>(
                query,
                new { CodigoAgenda = codigoAgenda }
            );

            if (usuario == null)
            {
                Console.WriteLine($"⚠ No se encontró un usuario con CodigoAgenda: {codigoAgenda}");
            }
            else
            {
                Console.WriteLine($"✅ Usuario encontrado en la BD: {usuario.CodAgenda}, {usuario.Username}");
            }

            return usuario;
        }



        public async Task GuardarUsuarioAsync(UsuarioDto usuario)
        {
            if (usuario == null)
            {
                throw new ArgumentNullException(nameof(usuario), "❌ ERROR: El usuario a guardar no puede ser nulo.");
            }

            Console.WriteLine($"📢 Guardando usuario en la BD:");
            Console.WriteLine($"🔹 CodAgenda: {usuario.CodAgenda}");
            Console.WriteLine($"🔹 Username: {usuario.Username}");
            Console.WriteLine($"🔹 Nombre: {usuario.Nombre}");
            Console.WriteLine($"🔹 Email: {usuario.Email}");

            using var connection = Connection;
            var query = "EXEC sp_InsertarUsuario @CodAgenda, @Username, @Nombre, @Email, @CargoId";

            await connection.ExecuteAsync(query, usuario);

            Console.WriteLine("✅ Usuario guardado correctamente en la BD.");
        }

    }
}
