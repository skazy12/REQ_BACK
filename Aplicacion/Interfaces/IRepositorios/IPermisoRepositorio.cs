﻿using Aplicacion.DTOs;

namespace Aplicacion.Interfaces
{
    public interface IPermisoRepositorio
    {
        Task<IEnumerable<PermisoDTO>> ObtenerTodosAsync();
        Task<PermisoDTO> ObtenerPorIdAsync(int id);
        Task AgregarAsync(PermisoDTO dto);
        Task ModificarAsync(PermisoDTO dto);
        Task DesactivarAsync(int id);
    }
}
