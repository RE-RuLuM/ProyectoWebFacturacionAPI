using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IClienteService
    {
        public Task<ICollection<Cliente>> ObtenerClientes();
        public Task<Cliente> ObtenerClientePorId(int id);
        public Task<int> AgregarCliente(ClienteDTO clienteDTO);
        public Task<int> ActualizarCliente(ClienteDTO clienteDTO);
        public Task<int> EliminarCliente(int id);
    }
}
