using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class UsuarioCargoConfiguracion : IEntityTypeConfiguration<UsuarioCargo>
    {
        public void Configure(EntityTypeBuilder<UsuarioCargo> builder)
        {
            builder.ToTable("usuario_cargo");

            builder.HasKey(uc => uc.UsuarioCargoId);

            builder.Property(uc => uc.UsuarioCargoId)
                   .HasColumnName("usuario_cargo_id");

            builder.Property(uc => uc.UsuarioCodAgenda)
                   .HasColumnName("usuario_cod_agenda")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(uc => uc.CargoId)
                   .HasColumnName("cargo_id")
                   .IsRequired();

            builder.Property(uc => uc.AsignadoPor)
                   .HasColumnName("asignado_por")
                   .HasMaxLength(10);

            builder.Property(uc => uc.FechaAsignacion)
                   .HasColumnName("fecha_asignacion")
                   .HasColumnType("datetime")
                   .IsRequired();

            builder.Property(uc => uc.FechaRemocion)
                   .HasColumnName("fecha_remocion")
                   .HasColumnType("datetime");

            builder.Property(uc => uc.Activo)
                   .HasColumnName("activo")
                   .HasColumnType("bit");

            builder.HasOne(uc => uc.Usuario)
                   .WithMany(u => u.UsuarioCargo)
                   .HasForeignKey(uc => uc.UsuarioCodAgenda)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(uc => uc.Cargo)
                   .WithMany(c => c.UsuariosCargo)
                   .HasForeignKey(uc => uc.CargoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
