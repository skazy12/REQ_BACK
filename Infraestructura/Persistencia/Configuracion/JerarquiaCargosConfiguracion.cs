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

            builder.Property(jc => jc.JerarquiaCargosId)
                   .HasColumnName("jerarquia_cargos_id");

            builder.Property(jc => jc.CargoIdAsignado)
                   .HasColumnName("cargo_id_asignado")
                   .IsRequired();

            builder.Property(jc => jc.CargoIdInferior)
                   .HasColumnName("cargo_id_inferior")
                   .IsRequired(false);

            builder.Property(jc => jc.FechaAsignacion)
                   .HasColumnName("fecha_asignacion")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(jc => jc.Activo)
                   .HasColumnName("activo")
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(jc => jc.ModificadoPor)
                   .HasColumnName("modificado_por")
                   .HasMaxLength(10);

            builder.HasOne(jc => jc.CargoAsignado)
                   .WithMany()
                   .HasForeignKey(jc => jc.CargoIdAsignado)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
