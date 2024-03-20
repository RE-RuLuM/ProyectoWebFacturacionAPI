using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Services;

namespace ProyectoWebFacturacionAPI.Controllers
{
    [Authorize]
    [Route("api/facturas")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturaController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpGet]
        public async Task<ActionResult> ListarFacturas()
        {
            var facturas = await _facturaService.ListarFacturas();

            return Ok(facturas);
        }

        [HttpPost]
        public async Task<ActionResult> EmitirFactura(FacturaDTO facturaDTO)
        {
            facturaDTO.UsuarioCreacion = User?.Identity?.Name;
            var response = await _facturaService.EmitirFactura(facturaDTO);

            return Created(Url.Action(nameof(EmitirFactura)), response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarFactura(int id)
        {
            var resultado = await _facturaService.EliminarFactura(id);

            return Ok();
        }
    }
}
