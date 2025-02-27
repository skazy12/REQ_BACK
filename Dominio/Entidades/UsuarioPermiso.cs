

namespace Dominio.Entidades
{
    public class UsuarioPermiso
    {
        public int UsuarioPermisoId { get; set; } // PK
        public string UsuarioCodAgenda { get; set; } // FK
        public int PermisoId { get; set; } // FK

        public Usuario Usuario { get; set; }
        public Permiso Permiso { get; set; }
    }
}
