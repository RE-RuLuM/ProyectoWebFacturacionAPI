using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils.QueryParams;

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

        public Task<Cliente> ObtenerClientePorId(int id) => 
            _context.Clientes.SingleAsync(c => c.Id == id);

        public async Task<ICollection<Cliente>> ObtenerClientes(ClienteQueryParams query)
        {
            var queryDB = _context.Clientes.Where(c => c.Activo);

            if (query.Nombres is not null)
                queryDB = queryDB.Where(c => c.Nombres.ToUpper().Contains(query.Nombres.ToUpper()));

            if (query.RucDni is not null)
                queryDB = queryDB.Where(c => c.RucDni.ToUpper().Equals(query.RucDni));

            if (query.Correo is not null)
                queryDB = queryDB.Where(c => c.Correo.ToUpper().Contains(query.Correo.ToUpper()));

            return await queryDB.ToListAsync();
        }
    }
}
