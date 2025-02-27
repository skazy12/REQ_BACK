namespace Dominio.Entidades
{
    public class Usuario
    {
        public string CodAgenda { get; set; }  // Código único del usuario (PK)
        public string Username { get; set; }  // Nombre de usuario
        public string Nombre { get; set; }  // Nombre del usuario
        public string Email { get; set; }  // Email del usuario
        public bool Activo { get; set; }  // Estado del usuario


        // Relaciones
        public ICollection<UsuarioCargo> UsuarioCargo { get; set; }
        public ICollection<UsuarioPermiso> UsuarioPermiso { get; set; }
    }
}
