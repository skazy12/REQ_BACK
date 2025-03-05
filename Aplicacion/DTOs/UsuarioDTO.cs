using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.DTOs
{
    public class UsuarioDto
    {
        public string CodAgenda { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool? Activo { get; set; }
        public int CargoId { get; set; }
        public string? CargoNombre { get; set; }
    }


}
