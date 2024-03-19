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
                Stock = productoDTO.Stock
            };

            _context.Productos.Add(producto);

            return _context.SaveChangesAsync();
        }

        public async Task<int> EliminarProducto(int id)
        {
            var producto = await ObtenerProductoPorId(id);

            producto.Activo = false;
            producto.FechaEliminacion = DateTime.Now;

            return await _context.SaveChangesAsync();
        }

        public Task<Producto> ObtenerProductoPorId(int id) =>
            _context.Productos.SingleAsync(p =>  p.Id == id);

        public Task<List<Producto>> ObtenerProductos() => 
            _context.Productos.Where(p => p.Activo).ToListAsync();
    }
}
