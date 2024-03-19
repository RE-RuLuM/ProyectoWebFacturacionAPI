using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IClienteService
    {
        public Task<List<Cliente>> ObtenerClientes();
        public Task<Cliente> ObtenerClientePorId(int id);
        public Task<int> AgregarCliente(ClienteDTO cliente);
        public Task<int> ActualizarCliente(ClienteDTO cliente);
        public Task<int> EliminarCliente(int id);
    }
}
