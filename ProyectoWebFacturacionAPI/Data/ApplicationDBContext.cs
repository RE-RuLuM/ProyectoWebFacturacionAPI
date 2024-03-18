using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Models;

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
    }
}
