
namespace Aplicacion.DTOs
{
    public class UsuarioCargoDto
    {
        public int UsuarioCargoId { get; set; }
        public string UsuarioCodAgenda { get; set; }
        public int CargoId { get; set; }
        public string AsignadoPor { get; set; }
        public DateTime? FechaAsignacion { get; set; }
        public DateTime? FechaRemocion { get; set; }
        public bool Activo { get; set; }
    }
}
