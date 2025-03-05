using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio.Entidades
{
    public class Usuario
    {
        [Column("cod_agenda")]
        public string CodAgenda { get; set; }  // Código único del usuario (PK)
        public string Username { get; set; }  // Nombre de usuario
        public string Nombre { get; set; }  // Nombre del usuario
        public string Email { get; set; }  // Email del usuario
        public bool Activo { get; set; }  // Estado del usuario


        // Relaciones
        public ICollection<UsuarioPermiso> UsuarioPermiso { get; set; } = new List<UsuarioPermiso>();
        public ICollection<UsuarioCargo> UsuarioCargo { get; set; } = new List<UsuarioCargo>();
    }
}
