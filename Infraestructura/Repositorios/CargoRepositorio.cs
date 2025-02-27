using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;
namespace Infraestructura.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly AplicacionDbContext _context;
        public CargoRepositorio(AplicacionDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cargo>> ObtenerTodosAsync()
        {
            return await _context.Cargos.FromSqlRaw("EXEC sp_ObtenerCargos").ToListAsync();
        }

        public async Task<Cargo> ObtenerPorIdAsync(int id)
        {
            return (await _context.Cargos
                .FromSqlRaw($"EXEC sp_ObtenerCargoPorId {id}")
                .ToListAsync())
                .FirstOrDefault();
        }



        public async Task AgregarAsync(Cargo cargo)
        {
            await _context.Database.ExecuteSqlRawAsync(
                $"EXEC sp_AgregarCargo '{cargo.Nombre}', '{cargo.Descripcion}', '{cargo.CreadoPor}'"
            );
        }


        public async Task ModificarAsync(Cargo cargo)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC sp_ModificarCargo {cargo.CargoId}, '{cargo.Nombre}', '{cargo.Descripcion}'");
        }

        public async Task DesactivarAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC sp_DesactivarCargo {id}");
        }
    }
}
