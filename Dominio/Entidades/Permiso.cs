using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Permiso
    {
        public int PermisoId { get; set; }  // PK
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }
        public Boolean Activo { get; set; }

        // Relaciones
        public ICollection<UsuarioPermiso> UsuarioPermiso { get; set; }
        public ICollection<CargoPermiso> CargoPermiso { get; set; }
    }
}

