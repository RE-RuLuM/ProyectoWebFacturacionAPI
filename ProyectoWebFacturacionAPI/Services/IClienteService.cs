using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Utils.QueryParams;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IClienteService
    {
        public Task<ICollection<Cliente>> ObtenerClientes(ClienteQueryParams query);
        public Task<Cliente> ObtenerClientePorId(int id);
        public Task<int> AgregarCliente(ClienteDTO clienteDTO);
        public Task<int> ActualizarCliente(ClienteDTO clienteDTO);
        public Task<int> EliminarCliente(int id);
    }
}
