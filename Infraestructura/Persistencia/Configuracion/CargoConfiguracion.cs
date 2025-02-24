using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class CargoConfiguracion : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.ToTable("cargo");

            builder.HasKey(c => c.CargoId);

            builder.Property(c => c.CargoId)
                   .HasColumnName("cargo_id");

            builder.Property(c => c.Nombre)
                   .HasColumnName("nombre")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(c => c.Descripcion)
                   .HasColumnName("descripcion")
                   .HasMaxLength(255);

            builder.Property(c => c.Activo)
                   .HasColumnName("activo")
                   .IsRequired();

            builder.Property(c => c.FechaCreacion)
                   .HasColumnName("fecha_creacion");

            builder.Property(c => c.FechaActualizacion)
                   .HasColumnName("fecha_actualizacion");

            builder.Property(c => c.CreadoPor)
                   .HasColumnName("creado_por")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.HasMany(c => c.UsuariosCargos)
                   .WithOne(uc => uc.Cargo)
                   .HasForeignKey(uc => uc.CargoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
