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

            builder.Property(cp => cp.CargoPermisoId).HasColumnName("cargo_permiso_id");

            builder.Property(cp => cp.CargoId)
                   .HasColumnName("cargo_id")
                   .IsRequired();

            builder.Property(cp => cp.PermisoId)
                   .HasColumnName("Permisos_id")
                   .IsRequired();
            builder.Property(cp => cp.Activo)  // Agregamos la nueva propiedad
                  .HasColumnName("activo")
                  .HasDefaultValue(true) // Opcional: asigna true por defecto
                  .IsRequired();
        }
    }
}
