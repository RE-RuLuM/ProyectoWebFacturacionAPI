using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IProductoService
    {
        public Task<List<Producto>> ObtenerProductos();
        public Task<Producto?> ObtenerProductoPorId(int id);
        public Task<Producto?> ObtenerProductoPorCodigo(string codigo);
        public Task<bool> VerificarStockDisponible(DetalleFacturaDTO item);
        public Task<int> DescontarStock(int id, int cantidad);
        public Task<int> DescontarStock(string codigo, int cantidad);
        public Task<int> AgregarProducto(ProductoDTO productoDTO);
        public Task<int> ActualizarProducto(ProductoDTO productoDTO);
        public Task<int> EliminarProducto(int id);
    }
}
