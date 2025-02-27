// Archivo: Aplicacion/Servicios/CargoPermisoServicio.cs
using Aplicacion.DTOs;
using Aplicacion.Interfaces;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public class CargoPermisoServicio : ICargoPermisoServicio
    {
        private readonly ICargoPermisoRepositorio _repositorio;

        public CargoPermisoServicio(ICargoPermisoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<PermisoDTO>> ObtenerPermisosActivosPorCargoAsync(int cargoId)
        {
            var permisos = await _repositorio.ObtenerPermisosActivosPorCargoAsync(cargoId);
            return permisos.Select(p => new PermisoDTO
            {
                PermisoId = p.PermisoId,
                Descripcion = p.Descripcion,
                Activo = p.Activo
            });
        }

        public async Task ActualizarPermisosCargoAsync(CargoPermisoDTO dto)
        {
            
            foreach (var permiso in dto.Permisos)
            {
                await _repositorio.ActualizarPermisoCargoAsync(dto.CargoId, permiso.PermisoId, permiso.Asignado, "admin");
            }
        }
    }
}
