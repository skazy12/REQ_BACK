using System.Data;

using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace Infraestructura.Repositorios
{
    public abstract class DapperRepository
    {
        private readonly string _connectionString;

        protected DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        protected IDbConnection Connection => new SqlConnection(_connectionString);
    }
}
