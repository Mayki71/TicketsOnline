using APITicketsOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace APITicketsOnline.Data
{
    public class ConciertosContext : DbContext
    {
        public ConciertosContext(DbContextOptions options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<GeneroMusical> GenerosMusicales { get; set; }
        public DbSet<Organizador> Organizadores { get; set; }
        public DbSet<Concierto> Conciertos { get; set; }
        public DbSet<TipoEntrada> TiposDeEntrada { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Entrada> Entradas { get; set; }
        public DbSet<Pago> Pagos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tablas
            modelBuilder.Entity<TipoEntrada>().ToTable("tipos_de_entrada");
            modelBuilder.Entity<GeneroMusical>().ToTable("generos_musicales");
            modelBuilder.Entity<Pais>().ToTable("paises");
            modelBuilder.Entity<Pago>().ToTable("pagos");
            modelBuilder.Entity<Concierto>().ToTable("conciertos");
            modelBuilder.Entity<Usuario>().ToTable("usuarios");
            modelBuilder.Entity<Rol>().ToTable("roles");
            modelBuilder.Entity<Ciudad>().ToTable("ciudades");
            modelBuilder.Entity<Organizador>().ToTable("organizadores");
            modelBuilder.Entity<Orden>().ToTable("ordenes");
            modelBuilder.Entity<Entrada>().ToTable("entradas");

            // Precisión de decimales
            modelBuilder.Entity<Orden>().Property(o => o.Total).HasPrecision(18, 2);
            modelBuilder.Entity<Pago>().Property(p => p.Monto).HasPrecision(18, 2);
            modelBuilder.Entity<TipoEntrada>().Property(t => t.Precio).HasPrecision(18, 2);

            // Relaciones
            modelBuilder.Entity<TipoEntrada>()
                .HasOne(t => t.Concierto)
                .WithMany(c => c.TiposDeEntrada)
                .HasForeignKey(t => t.ConciertoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}