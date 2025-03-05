

namespace Dominio.Entidades
{
    public class Cargo
    {
        public int CargoId { get; set; }  // PK
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string CreadoPor { get; set; } = "Desconocido"; // ✅ Valor por defecto para evitar problemas con NULL


        // Relaciones
        public ICollection<UsuarioCargo> UsuariosCargo { get; set; }
        public ICollection<CargoPermiso> CargoPermiso { get; set; }
    }
}
