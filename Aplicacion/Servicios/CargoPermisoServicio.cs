using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;


namespace Aplicacion.Servicios
{
    public class CargoPermisoServicio : ICargoPermisoServicio
    {
        private readonly ICargoPermisoRepositorio _cargoPermisoRepositorio;

        public CargoPermisoServicio(ICargoPermisoRepositorio cargoPermisoRepositorio)
        {
            _cargoPermisoRepositorio = cargoPermisoRepositorio;
        }

        public async Task<IEnumerable<CargoPermisoDto>> ObtenerCargoPermisosAsync()
        {
            var lista = await _cargoPermisoRepositorio.ObtenerCargoPermisosAsync();
            return lista.Select(cp => new CargoPermisoDto
            {
                CargoPermisoId = cp.CargoPermisoId,
                CargoId = cp.CargoId,
                PermisoId = cp.PermisoId,
                Activo = cp.Activo ?? false,
                ModificadoPor = cp.ModificadoPor
            });
        }

        public async Task<CargoPermisoDto> ObtenerCargoPermisoPorIdAsync(int id)
        {
            var cargoPermiso = await _cargoPermisoRepositorio.ObtenerCargoPermisoPorIdAsync(id);
            if (cargoPermiso == null) return null;

            return new CargoPermisoDto
            {
                CargoPermisoId = cargoPermiso.CargoPermisoId,
                CargoId = cargoPermiso.CargoId,
                PermisoId = cargoPermiso.PermisoId,
                Activo = cargoPermiso.Activo ?? false,
                ModificadoPor = cargoPermiso.ModificadoPor
            };
        }

        public async Task CrearCargoPermisoAsync(CargoPermisoDto cargoPermisoDto)
        {
            var cargoPermiso = new CargoPermiso
            {
                CargoId = cargoPermisoDto.CargoId,
                PermisoId = cargoPermisoDto.PermisoId,
                Activo = true,
                ModificadoPor = cargoPermisoDto.ModificadoPor
            };

            await _cargoPermisoRepositorio.CrearCargoPermisoAsync(cargoPermiso);
        }

        public async Task ModificarCargoPermisoAsync(int id, CargoPermisoDto cargoPermisoDto)
        {
            var cargoPermiso = new CargoPermiso
            {
                CargoPermisoId = id,
                CargoId = cargoPermisoDto.CargoId,
                PermisoId = cargoPermisoDto.PermisoId,
                ModificadoPor = cargoPermisoDto.ModificadoPor
            };

            await _cargoPermisoRepositorio.ModificarCargoPermisoAsync(id, cargoPermiso);
        }

        public async Task DesactivarCargoPermisoAsync(int id)
        {
            await _cargoPermisoRepositorio.DesactivarCargoPermisoAsync(id);
        }
    }
}
