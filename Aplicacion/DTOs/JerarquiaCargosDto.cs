using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class JerarquiaCargosDto
    {
        public int JerarquiaCargosId { get; set; }
        public int CargoIdAsignado { get; set; }
        public int? CargoIdInferior { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Activo { get; set; }
        public string ModificadoPor { get; set; }
    }
}
