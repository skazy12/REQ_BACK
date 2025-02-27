using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class UsuarioPermisoConfiguracion : IEntityTypeConfiguration<UsuarioPermiso>
    {
        public void Configure(EntityTypeBuilder<UsuarioPermiso> builder)
        {
            builder.ToTable("usuario_permiso");

            builder.HasKey(up => up.UsuarioPermisoId);

            builder.Property(up => up.UsuarioPermisoId)
                   .HasColumnName("usuario_permisos_id");

            builder.Property(up => up.UsuarioCodAgenda)
                   .HasColumnName("usuario_cod_agenda")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(up => up.PermisoId)
                   .HasColumnName("permiso_id")
                   .IsRequired();

            builder.HasOne(up => up.Usuario)
                   .WithMany(u => u.UsuarioPermiso)
                   .HasForeignKey(up => up.UsuarioCodAgenda)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Permiso)
                   .WithMany(p => p.UsuarioPermiso)
                   .HasForeignKey(up => up.PermisoId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
