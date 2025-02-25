using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Infraestructura.Persistencia.Configuracion;

namespace Infraestructura.Persistencia
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(DbContextOptions<AplicacionDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioCargo> UsuarioCargos { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<UsuarioPermiso> UsuarioPermisos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<CargoPermiso> CargoPermisos { get; set; }
        public DbSet<JerarquiaCargos> JerarquiasCargos { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new CargoConfiguracion());
            modelBuilder.ApplyConfiguration(new PermisoConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioCargoConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuarioPermisoConfiguracion());
            modelBuilder.ApplyConfiguration(new CargoPermisoConfiguracion());
            modelBuilder.ApplyConfiguration(new JerarquiaCargosConfiguracion());

            base.OnModelCreating(modelBuilder);
        }
    }
}
