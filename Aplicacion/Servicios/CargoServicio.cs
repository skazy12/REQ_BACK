using Aplicacion.DTOs;
using Aplicacion.Interfaces;

namespace Aplicacion.Servicios
{
    public class CargoServicio : ICargoServicio
    {
        private readonly ICargoRepositorio _cargoRepositorio;

        public CargoServicio(ICargoRepositorio cargoRepositorio)
        {
            _cargoRepositorio = cargoRepositorio;
        }

        public async Task<IEnumerable<CargoDTO>> ObtenerTodosAsync()
        {
            return await _cargoRepositorio.ObtenerTodosAsync();
        }

        public async Task<CargoDTO> ObtenerPorIdAsync(int id)
        {
            var cargo = await _cargoRepositorio.ObtenerPorIdAsync(id);
            if (cargo == null)
                throw new KeyNotFoundException($"El cargo con ID {id} no fue encontrado.");

            return cargo;
        }

        public async Task AgregarAsync(CargoDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Nombre))
                throw new ArgumentException("El nombre del cargo es obligatorio.");

            if (string.IsNullOrEmpty(dto.Descripcion))
                throw new ArgumentException("La descripción del cargo es obligatoria.");
            dto.CreadoPor = "admin"; // Luego se cambiará por el usuario logueado

            await _cargoRepositorio.AgregarAsync(dto);
        }

        public async Task ModificarAsync(CargoDTO dto)
        {
            var cargoExistente = await _cargoRepositorio.ObtenerPorIdAsync(dto.CargoId);
            if (cargoExistente == null)
                throw new KeyNotFoundException($"El cargo con ID {dto.CargoId} no fue encontrado.");

            await _cargoRepositorio.ModificarAsync(dto);
        }

        public async Task DesactivarAsync(int id)
        {
            var cargoExistente = await _cargoRepositorio.ObtenerPorIdAsync(id);
            if (cargoExistente == null)
                throw new KeyNotFoundException($"El cargo con ID {id} no fue encontrado.");

            await _cargoRepositorio.DesactivarAsync(id);
        }
    }
}
