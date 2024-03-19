using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IProductoService
    {
        public Task<List<Producto>> ObtenerProductos();
        public Task<Producto> ObtenerProductoPorId(int id);
        public Task<int> AgregarProducto(ProductoDTO productoDTO);
        public Task<int> ActualizarProducto(ProductoDTO productoDTO);
        public Task<int> EliminarProducto(int id);
    }
}
