

namespace Dominio.Entidades
{
    public class Cargo
    {
        public int CargoId { get; set; }  // PK
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string CreadoPor { get; set; }

        // Relaciones
        public ICollection<UsuarioCargo> UsuariosCargos { get; set; }
        public ICollection<CargoPermiso> CargoPermisos { get; set; }
    }
}
