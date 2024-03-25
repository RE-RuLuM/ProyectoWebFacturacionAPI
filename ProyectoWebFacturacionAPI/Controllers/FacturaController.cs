using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils.Responses;

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

            return Ok(new ResponseResource<ICollection<CabFactura>>
            {
                Msg = "Obtenido con éxito",
                Data = facturas
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> ObtenerFacturaPorId(int id)
        {
            var factura = await _facturaService.ObtenerFacturaPorId(id);

            return Ok(new ResponseResource<CabFactura>
            {
                Msg = "Obtenido con éxito",
                Data = factura
            });
        }

        [HttpPost]
        public async Task<ActionResult> EmitirFactura(FacturaDTO facturaDTO)
        {
            facturaDTO.UsuarioCreacion = User?.Identity?.Name;
            var factura = await _facturaService.EmitirFactura(facturaDTO);

            if (factura is null)
                return Problem();

            return Created(Url.Action(nameof(EmitirFactura)), new ResponseResource<CabFactura>
            {
                Msg = $"Factura {factura.NumeroFactura} emitida",
                Data = factura
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarFactura(int id)
        {
            await _facturaService.EliminarFactura(id);

            return Ok();
        }
    }
}
