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

            // Definir clave primaria
            builder.HasKey(u => u.CodAgenda);

            // Definir restricciones de columnas
            builder.Property(u => u.CodAgenda)
                   .HasColumnName("cod_agenda")
                   .HasMaxLength(10)
                   .IsRequired();

            builder.Property(u => u.Username)
                   .HasColumnName("username")
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(u => u.Nombre)
                   .HasColumnName("nombre")
                   .HasMaxLength(100);

            builder.Property(u => u.Correo)
                   .HasColumnName("email")
                   .HasMaxLength(100);
            builder.Property(u => u.Activo)
                   .HasColumnName("activo")
                   .IsRequired();

            // Relaciones
            builder.HasMany(u => u.UsuarioCargos)
                   .WithOne(uc => uc.Usuario)
                   .HasForeignKey(uc => uc.UsuarioCodAgenda)
                   .OnDelete(DeleteBehavior.Restrict); // Evita borrado en cascada

            builder.HasMany(u => u.UsuarioPermisos)
                   .WithOne(up => up.Usuario)
                   .HasForeignKey(up => up.UsuarioCodAgenda)
                   .OnDelete(DeleteBehavior.Cascade); // Borra permisos cuando se elimina usuario
        }
    }
}
