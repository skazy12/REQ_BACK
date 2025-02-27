using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Persistencia.Configuracion
{
    public class UsuarioConfiguracion : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(u => u.CodAgenda);

            builder.Property(u => u.CodAgenda)
                   .HasColumnName("cod_agenda")
                   .HasMaxLength(10);

            builder.Property(u => u.Username)
                   .HasColumnName("username")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Nombre)
                   .HasColumnName("nombre")
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .HasColumnName("email")
                   .HasMaxLength(100);

            builder.Property(u => u.Activo)
                   .HasColumnName("activo")
                   .HasColumnType("bit");
        }
    }

}
