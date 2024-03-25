using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils.QueryParams;
using ProyectoWebFacturacionAPI.Utils.Responses;

namespace ProyectoWebFacturacionAPI.Controllers
{
    [Route("api/clientes")]
    [Authorize]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cliente>>> ListarClientes([FromQuery] ClienteQueryParams query)
        {
            var clientes = await _clienteService.ObtenerClientes(query);
            return Ok(new ResponseResource<ICollection<Cliente>> { 
                Msg = "Obtenido con éxito",
                Data = clientes
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> ObtenerCliente(int id)
        {
            var cliente = await _clienteService.ObtenerClientePorId(id);
            return Ok(new ResponseResource<Cliente>
            {
                Msg = "Obtenido con éxito",
                Data = cliente
            });
        }

        [HttpPost]
        public async Task<ActionResult> CrearCliente(ClienteDTO cliente)
        {
            var result = await _clienteService.AgregarCliente(cliente);

            return Created();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> ActualizarCliente(int id, ClienteDTO cliente)
        {
            cliente.Id = id;
            var result = await _clienteService.ActualizarCliente(cliente);

            return Created();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarCliente(int id)
        {
            var result = await _clienteService.EliminarCliente(id);

            return Ok(result);
        }
    }
}
