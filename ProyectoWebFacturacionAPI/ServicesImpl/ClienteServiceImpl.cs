using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;

namespace ProyectoWebFacturacionAPI.ServicesImpl
{
    public class ClienteServiceImpl : IClienteService
    {
        private readonly ApplicationDBContext _context;
        public ClienteServiceImpl(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<int> ActualizarCliente(ClienteDTO clienteReq)
        {
            var cliente = await ObtenerClientePorId((int) clienteReq.Id!);

            cliente.RucDni = clienteReq.RucDni;
            cliente.Nombres = clienteReq.Nombres;
            cliente.Apellidos = clienteReq.Apellidos;
            cliente.Direccion = clienteReq.Direccion;
            cliente.Correo = clienteReq.Correo;

            return await _context.SaveChangesAsync();
        }

        public Task<int> AgregarCliente(ClienteDTO clienteReq)
        {
            var cliente = new Cliente
            {
                RucDni = clienteReq.RucDni,
                Nombres = clienteReq.Nombres,
                Apellidos = clienteReq.Apellidos,
                Correo = clienteReq.Correo,
                Direccion = clienteReq.Direccion,
                Activo = true,
                FechaCreacion = DateTime.Now
            };

            _context.Clientes.Add(cliente);

            return _context.SaveChangesAsync();
        }

        public async Task<int> EliminarCliente(int id)
        {
            var cliente = await ObtenerClientePorId(id);

            cliente.Activo = false;
            cliente.FechaEliminacion = DateTime.Now;

            return await _context.SaveChangesAsync();
        }

        public Task<Cliente> ObtenerClientePorId(int id) => _context.Clientes.SingleAsync(c => c.Id == id);

        public async Task<ICollection<Cliente>> ObtenerClientes() => await _context.Clientes.Where(c => c.Activo).ToListAsync();
    }
}
