using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;

namespace ProyectoWebFacturacionAPI.ServicesImpl
{
    public class ProductoServiceImpl : IProductoService
    {
        private readonly ApplicationDBContext _context;

        public ProductoServiceImpl(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> ActualizarProducto(ProductoDTO productoDTO)
        {
            var producto = await ObtenerProductoPorId((int) productoDTO.Id!);

            if (producto is null)
                return 0;

            producto.Codigo = productoDTO.Codigo;
            producto.Nombre = productoDTO.Nombre;
            producto.Precio = productoDTO.Precio;
            producto.Stock = productoDTO.Stock;

            return await _context.SaveChangesAsync();
        }

        public Task<int> AgregarProducto(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Codigo = productoDTO.Codigo,
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Stock = productoDTO.Stock,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            _context.Productos.Add(producto);

            return _context.SaveChangesAsync();
        }

        public async Task<int> EliminarProducto(int id)
        {
            var producto = await ObtenerProductoPorId(id);

            if (producto is null)
                return 0;

            producto.Activo = false;
            producto.FechaEliminacion = DateTime.Now;

            return await _context.SaveChangesAsync();
        }

        public Task<Producto?> ObtenerProductoPorId(int id) =>
            _context.Productos.FirstOrDefaultAsync(p =>  p.Id == id);

        public Task<Producto?> ObtenerProductoPorCodigo(string codigo) =>
            _context.Productos.FirstOrDefaultAsync(p => p.Codigo.Equals(codigo));

        public Task<List<Producto>> ObtenerProductos() => 
            _context.Productos.Where(p => p.Activo).ToListAsync();

        public async Task<bool> VerificarStockDisponible(DetalleFacturaDTO item)
        {
            var producto = await ObtenerProductoPorCodigo(item.CodigoProducto);

            return producto?.Stock > item.Cantidad;
        }

        public async Task<int> DescontarStock(int id, int cantidad)
        {
            var producto = await ObtenerProductoPorId(id);

            producto.Stock -= cantidad;

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DescontarStock(string codigo, int cantidad)
        {
            var producto = await ObtenerProductoPorCodigo(codigo);

            producto.Stock -= cantidad;

            return await _context.SaveChangesAsync();
        }
    }
}
