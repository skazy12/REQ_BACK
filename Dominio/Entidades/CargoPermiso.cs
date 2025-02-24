using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class CargoPermiso
    {
        public int CargoPermisoId { get; set; }  // PK
        public int CargoId { get; set; }  // FK
        public int PermisoId { get; set; }  // FK
        public string ModificadoPor { get; set; }
        public bool? Activo { get; set; }

        public Cargo Cargo { get; set; }
        public Permiso Permiso { get; set; }
    }
}
