namespace Dominio.Entidades
{
    public class JerarquiaCargos
    {
        public int JerarquiaCargosId { get; set; } // PK
        public int CargoIdAsignado { get; set; } // FK
        public int? CargoIdInferior { get; set; } // Puede ser NULL, no FK
        public DateTime FechaAsignacion { get; set; }
        public bool Activo { get; set; }
        public string ModificadoPor { get; set; }

        public Cargo CargoAsignado { get; set; }
    }
}
