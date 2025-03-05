using System.Collections.Generic;

namespace Aplicacion.DTOs
{
    public class UsuarioConPermisoYCargoDTO
    {
        public string CodAgenda { get; set; }
        public string Username { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
        public string Permiso { get; set; }  // Dato plano del SP
        public string Cargo { get; set; }    // Dato plano del SP
    }


}
