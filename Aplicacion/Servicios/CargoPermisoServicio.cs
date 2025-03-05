using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class CargoPermisoServicio : ICargoPermisoServicio
    {
        private readonly ICargoPermisoRepositorio _cargoPermisoRepositorio;

        public CargoPermisoServicio(ICargoPermisoRepositorio cargoPermisoRepositorio)
        {
            _cargoPermisoRepositorio = cargoPermisoRepositorio;
        }

        public async Task<IEnumerable<PermisoDTO>> ObtenerPermisosPorCargoAsync(int cargoId)
        {
            return await _cargoPermisoRepositorio.ObtenerPermisosPorCargoAsync(cargoId);
        }

        public async Task ActualizarPermisosCargoAsync(CargoPermisoDTO dto)
        {
            if (dto == null || dto.Permisos == null || dto.Permisos.Count == 0)
                throw new ArgumentException("La lista de permisos no puede estar vacía.");

            string usuarioLogueado = "admin"; // Asignamos "admin" directamente, más adelante será dinámico con autenticación

            // Se asigna el usuario logueado en cada permiso antes de enviarlo al repositorio
            foreach (var permiso in dto.Permisos)
            {
                permiso.ModificadoPor = usuarioLogueado;
            }

            await _cargoPermisoRepositorio.ActualizarPermisosCargoAsync(dto);
        }


    }
}
