using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class UsuarioCargoDTO
    {
        public class UsuarioCargoListadoDTO
        {
            public int CargoId { get; set; }
            public string NombreCargo { get; set; }
            public bool Activo { get; set; } // Si está asignado al usuario, `true`; si no, `false`.
        }
        public class UsuarioCargoUpdateDTO
        {
            public string UsuarioCodAgenda { get; set; }
            public List<int> CargosAsignados { get; set; }
            public string ModificadoPor { get; set; }  // 🔥 Agregado para auditoría
        }

        public class CargoAsignadoDTO
        {
            public int CargoId { get; set; }  // ID del cargo
            public bool Activo { get; set; }  // Indica si está asignado o no
            public string ModificadoPor { get; set; } // Usuario que realiza la modificación
        }


    }
}
