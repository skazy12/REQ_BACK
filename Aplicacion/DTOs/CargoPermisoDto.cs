using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class CargoPermisoDTO
    {
        public int CargoId { get; set; }
        public List<PermisoEstadoDTO> Permisos { get; set; }
    }

    public class PermisoEstadoDTO
    {
        public int PermisoId { get; set; }
        public bool Asignado { get; set; } // TRUE si está asignado, FALSE si se debe desasignar
        public string? ModificadoPor { get; set; } // Se asignará en el servicio
    }
}
