using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class UsuarioCargo
    {
        public int UsuarioCargoId { get; set; }  // PK
        public string UsuarioCodAgenda { get; set; }  // FK
        public int CargoId { get; set; }  // FK
        public string AsignadoPor { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public DateTime? FechaRemocion { get; set; }
        public bool Activo { get; set; }

        public Usuario Usuario { get; set; }
        public Cargo Cargo { get; set; }
    }
}
