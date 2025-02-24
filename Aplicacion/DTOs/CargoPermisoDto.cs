

namespace Aplicacion.DTOs
{
    public class CargoPermisoDto
    {
        public int CargoPermisoId { get; set; }
        public int CargoId { get; set; }
        public int PermisoId { get; set; }
        public bool Activo { get; set; }
        public string ModificadoPor { get; set; }
    }
}
