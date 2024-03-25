using Microsoft.AspNetCore.Mvc;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProyectoWebFacturacionAPI.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: api/productos
        [HttpGet]
        public async Task<ActionResult<ResponseResource<ICollection<Producto>>>> ObtenerProductos()
        {
            var productos = await _productoService.ObtenerProductos();

            return Ok(new ResponseResource<ICollection<Producto>> { 
                Msg = "Obtenido con éxito",
                Data = productos
            });
        }

        // GET api/productos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseResource<Producto>>> ObtenerProducto(int id)
        {
            var producto = await _productoService.ObtenerProductoPorId(id);

            return Ok(new ResponseResource<Producto> {
                Msg = "Obtenido con éxito",
                Data = producto
            });
        }

        // POST api/productos
        [HttpPost]
        public async Task<ActionResult> CrearProducto(ProductoDTO productoDTO)
        {
            await _productoService.AgregarProducto(productoDTO);

            return Created();
        }

        // PUT api/productos/5
        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarProducto(int id, ProductoDTO productoDTO)
        {
            productoDTO.Id = id;

            await _productoService.ActualizarProducto(productoDTO);

            return Created();
        }

        // DELETE api/productos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _productoService.EliminarProducto(id);

            return Ok(result);
        }
    }
}
