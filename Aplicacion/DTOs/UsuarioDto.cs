
namespace Aplicacion.DTOs
{
    public class UsuarioDto
    {
        public string CodAgenda { get; set; }  // ✅ ID único del usuario
        public string Username { get; set; }  // Nombre de usuario
        public string Nombre { get; set; }  // Nombre completo del usuario
        public string Correo { get; set; }  // Email del usuario
        public bool Activo { get; set; }  // Estado del usuario

        //  Lista de cargos asociados al usuario
        public List<string> Cargos { get; set; }
    }
}
