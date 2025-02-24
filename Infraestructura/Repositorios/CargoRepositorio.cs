using Aplicacion.Interfaces;
using Dominio.Entidades;
using Infraestructura.Persistencia;
using Microsoft.EntityFrameworkCore;


namespace Infraestructura.Repositorios
{
    public class CargoRepositorio : ICargoRepositorio
    {
        private readonly AplicacionDbContext _contexto;

        public CargoRepositorio(AplicacionDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Cargo>> ObtenerCargosAsync()
        {
            return await _contexto.Cargos.ToListAsync();
        }

        public async Task CrearCargoAsync(Cargo cargo)
        {
            _contexto.Cargos.Add(cargo);
            await _contexto.SaveChangesAsync();
        }

        public async Task ModificarCargoAsync(int id, Cargo cargo)
        {
            var cargoExistente = await _contexto.Cargos.FindAsync(id);
            if (cargoExistente != null)
            {
                cargoExistente.Nombre = cargo.Nombre;
                cargoExistente.Descripcion = cargo.Descripcion;
                cargoExistente.Activo = cargo.Activo;
                cargoExistente.FechaActualizacion = cargo.FechaActualizacion;

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task DesactivarCargoAsync(int id)
        {
            var cargo = await _contexto.Cargos.FindAsync(id);
            if (cargo != null)
            {
                cargo.Activo = false;
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
