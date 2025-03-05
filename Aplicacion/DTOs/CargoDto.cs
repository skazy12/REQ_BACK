

namespace Aplicacion.DTOs
{
    public class CargoDTO
    {
        public int CargoId { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? CreadoPor { get; set; }
        
        public bool? Activo { get; set; }
    }
}
