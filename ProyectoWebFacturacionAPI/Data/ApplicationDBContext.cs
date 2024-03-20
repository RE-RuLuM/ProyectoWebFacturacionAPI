using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Models;
using System.Reflection.Metadata;

namespace ProyectoWebFacturacionAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<CabFactura> CabFacturas { get; set; }
        public DbSet <DetalleFactura> DetalleFacturas { get; set; }
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalleFactura>()
                .HasOne(e => e.CabFactura)
                .WithMany(e => e.Detalles)
                .HasForeignKey(e => e.FacturaId)
                .IsRequired();
        }
    }
}
