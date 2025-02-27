using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class CargoPermisoConfiguracion : IEntityTypeConfiguration<CargoPermiso>
    {
        public void Configure(EntityTypeBuilder<CargoPermiso> builder)
        {
            builder.ToTable("cargo_permiso");

            builder.HasKey(cp => cp.CargoPermisoId);

            builder.Property(cp => cp.CargoPermisoId)
                   .HasColumnName("cargo_permiso_id");

            builder.Property(cp => cp.CargoId)
                   .HasColumnName("cargo_id")
                   .IsRequired();

            builder.Property(cp => cp.PermisoId)
                   .HasColumnName("permiso_id")
                   .IsRequired();

            builder.Property(cp => cp.Activo)
                   .HasColumnName("activo")
                   .HasColumnType("bit")
                   .IsRequired();

            builder.Property(cp => cp.ModificadoPor)
                   .HasColumnName("modificado_por")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.HasOne(cp => cp.Cargo)
                   .WithMany(c => c.CargoPermiso)
                   .HasForeignKey(cp => cp.CargoId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(cp => cp.Permiso)
                   .WithMany(p => p.CargoPermiso)
                   .HasForeignKey(cp => cp.PermisoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
