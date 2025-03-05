

namespace Aplicacion.DTOs
{
    public class PermisoDTO
    {
        public int PermisoId { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public string? CreadoPor {  get; set; }
        public int? asignado { get; set; } 
    }
}
