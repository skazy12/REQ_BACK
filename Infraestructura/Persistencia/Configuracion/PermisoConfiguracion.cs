using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class PermisoConfiguracion : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> builder)
        {
            builder.ToTable("permiso");

            builder.HasKey(p => p.PermisoId);

            builder.Property(p => p.PermisoId)
                   .HasColumnName("permiso_id");

            builder.Property(p => p.Descripcion)
                   .HasColumnName("descripcion")
                   .IsRequired();

            builder.Property(p => p.CreadoPor)
                   .HasColumnName("creado_por")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(p => p.Activo)
                   .HasColumnName("activo")
                   .HasColumnType("bit")
                   .IsRequired();
        }
    }
}
