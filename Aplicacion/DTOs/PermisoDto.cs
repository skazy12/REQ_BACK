
namespace Aplicacion.DTOs
{
    public class PermisoDto
    {
        public int PermisoId { get; set; }  // Se agrega el ID
        public string Descripcion { get; set; }
        public string CreadoPor { get; set; }  // Se añade para rastreo
        public bool Activo { get; set; }
    }
}
