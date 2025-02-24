using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class UsuarioPermisoConfiguracion : IEntityTypeConfiguration<UsuarioPermiso>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermiso> builder)
        {
            builder.ToTable("usuario_permisos");

            builder.HasKey(up => up.UsuarioPermisoId);

            builder.Property(up => up.UsuarioPermisoId).HasColumnName("usuario_permisos_id");

            builder.Property(up => up.UsuarioCodAgenda)
                   .HasColumnName("usuario_cod_agenda")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(up => up.PermisoId)
                   .HasColumnName("Permisos_id")
                   .IsRequired();
        }
    }
}
