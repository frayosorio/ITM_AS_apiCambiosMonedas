using apiCambiosMoneda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace apiCambiosMoneda.Infraestructura.Repositorio.Contextos
{
    public class CambiosMonedaContext : DbContext
    {
        public CambiosMonedaContext(DbContextOptions<CambiosMonedaContext> options)
           : base(options)
        {
        }

        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<CambioMoneda> CambiosMoneda { get; set; }
        public DbSet<Pais> Paises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moneda>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(m => m.Nombre).IsUnique();
            });

            modelBuilder.Entity<Pais>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(m => m.Nombre).IsUnique();
            });

            modelBuilder.Entity<CambioMoneda>()
                .HasKey(cm => new { cm.IdMoneda, cm.Fecha });

            modelBuilder.Entity<Pais>()
              .HasOne(p => p.Moneda)
              .WithMany()
              .HasForeignKey(p => p.IdMoneda)
              .IsRequired(false); 

            modelBuilder.Entity<CambioMoneda>()
               .HasOne(cm => cm.Moneda)
               .WithMany()
               .HasForeignKey(cm => cm.IdMoneda)
               .IsRequired(false); 
        }

    }
}
