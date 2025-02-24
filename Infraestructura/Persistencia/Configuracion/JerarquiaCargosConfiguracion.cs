using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class JerarquiaCargosConfiguracion : IEntityTypeConfiguration<JerarquiaCargos>
    {
        public void Configure(EntityTypeBuilder<JerarquiaCargos> builder)
        {
            builder.ToTable("jerarquia_cargos");

            builder.HasKey(jc => jc.JerarquiaCargosId);

            builder.Property(jc => jc.JerarquiaCargosId).HasColumnName("jerarquia_cargos_id");

            builder.Property(jc => jc.CargoIdAsignado)
                   .HasColumnName("cargo_id_asignado")
                   .IsRequired();

            builder.Property(jc => jc.CargoIdInferior)
                   .HasColumnName("cargo_id_inferior");

            builder.Property(jc => jc.FechaAsignacion)
                   .HasColumnName("fecha_asignacion");

            builder.Property(jc => jc.Activo)
                   .HasColumnName("activo")
                   .IsRequired();

            builder.Property(jc => jc.ModificadoPor)
                   .HasColumnName("modificado_por")
                   .HasMaxLength(10);

            // Configuración de las claves foráneas SIN CASCADA en ambas relaciones
            builder.HasOne(jc => jc.CargoAsignado)
                   .WithMany()
                   .HasForeignKey(jc => jc.CargoIdAsignado)
                   .OnDelete(DeleteBehavior.Restrict); // ❌ Evitar CASCADE

            builder.HasOne(jc => jc.CargoInferior)
                   .WithMany()
                   .HasForeignKey(jc => jc.CargoIdInferior)
                   .OnDelete(DeleteBehavior.NoAction); // ❌ No cascada para evitar loops
        }
    }
}
