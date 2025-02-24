using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;


namespace Aplicacion.Servicios
{
    public class CargoServicio : ICargoServicio
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public CargoServicio(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public async Task<IEnumerable<CargoDto>> ObtenerCargosAsync()
        {
            var cargos = await _cargoRepositorio.ObtenerCargosAsync();
            return cargos.Select(c => new CargoDto
            {
                CargoId = c.CargoId,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Activo = c.Activo
            });
        }

        public async Task CrearCargoAsync(CargoDto cargoDto)
        {
            var cargo = new Cargo
            {
                Nombre = cargoDto.Nombre,
                Descripcion = cargoDto.Descripcion,
                Activo = cargoDto.Activo,
                FechaCreacion = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow,
                CreadoPor = "ADMIN"
            };

            await _cargoRepositorio.CrearCargoAsync(cargo);
        }

        public async Task ModificarCargoAsync(int id, CargoDto cargoDto)
        {
            var cargo = new Cargo
            {
                CargoId = id,
                Nombre = cargoDto.Nombre,
                Descripcion = cargoDto.Descripcion,
                Activo = cargoDto.Activo,
                FechaActualizacion = DateTime.UtcNow
            };

            await _cargoRepositorio.ModificarCargoAsync(id, cargo);
        }

        public async Task DesactivarCargoAsync(int id)
        {
            await _cargoRepositorio.DesactivarCargoAsync(id);
        }
    }
}
