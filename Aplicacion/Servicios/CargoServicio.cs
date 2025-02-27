using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;
namespace Aplicacion.Servicios
{
    public class CargoServicio : ICargoServicio
    {
        private readonly ICargoRepositorio _repositorio;

        public CargoServicio(ICargoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<CargoDTO>> ObtenerTodosAsync()
        {
            var cargos = await _repositorio.ObtenerTodosAsync();
            return cargos.Select(c => new CargoDTO { CargoId = c.CargoId, Nombre = c.Nombre, Descripcion = c.Descripcion, Activo = c.Activo });
        }

        public async Task<CargoDTO> ObtenerPorIdAsync(int id)
        {
            var cargo = await _repositorio.ObtenerPorIdAsync(id);
            return cargo == null ? null : new CargoDTO { CargoId = cargo.CargoId, Nombre = cargo.Nombre, Descripcion = cargo.Descripcion, Activo = cargo.Activo };
        }

        public async Task AgregarAsync(CargoDTO dto)
        {
            var cargo = new Cargo
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                CreadoPor = "admin", // 🔹 Definir el usuario que crea el cargo
                Activo = true
            };

            await _repositorio.AgregarAsync(cargo);
        }


        public async Task ModificarAsync(CargoDTO dto)
        {
            var cargo = new Cargo { CargoId = (int)dto.CargoId, Nombre = dto.Nombre, Descripcion = dto.Descripcion, Activo = dto.Activo };
            await _repositorio.ModificarAsync(cargo);
        }

        public async Task DesactivarAsync(int id)
        {
            await _repositorio.DesactivarAsync(id);
        }
    }
}