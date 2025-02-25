namespace Aplicacion.DTOs
{
    public class UsuarioDetallesDto
    {
        public string CodAgenda { get; set; }
        public string Nombre { get; set; }
        public List<string> Cargos { get; set; }
        public List<string> Permisos { get; set; }
    }
}
