using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class SDMYDAContext : DbContext
    {
        public SDMYDAContext(DbContextOptions<SDMYDAContext> options): base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Mascota> Mascotas { get; set; }
        public DbSet<HoraProgramada> HorasProgramadas { get; set; }
        public DbSet<Detalle_Mascota_HoraProgramada> Detalles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Mascota>().ToTable("Mascota");
            modelBuilder.Entity<HoraProgramada>().ToTable("HoraProgramada");
            modelBuilder.Entity<Detalle_Mascota_HoraProgramada>().ToTable("Detalle");
        }
    }
}