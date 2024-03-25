using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils.Responses;
using System;

namespace ProyectoWebFacturacionAPI.ServicesImpl
{
    public class FacturaServiceImpl : IFacturaService
    {
        private readonly ApplicationDBContext _context;
        private readonly IProductoService _productoService;

        public FacturaServiceImpl(ApplicationDBContext context, IProductoService productoService)
        {
            _context = context;
            _productoService = productoService;
        }

        public async Task<int> EliminarFactura(int id)
        {
            var factura = await _context.CabFacturas.SingleAsync(f =>  f.Id == id);

            factura.Activo = false;
            factura.FechaEliminacion = DateTime.Now;

            return await _context.SaveChangesAsync();
        }

        public async Task<CabFactura> EmitirFactura(FacturaDTO facturaDTO)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                // Verificar que ningun producto seleccionado sobrepasa el stock
                foreach (var item in facturaDTO.Detalles)
                {
                    bool hayStockDisponible = await _productoService.VerificarStockDisponible(item);

                    if (!hayStockDisponible)
                        throw new Exception("No hay stock disponible de alguno de los productos");
                }

                ICollection<DetalleFactura> detalles = facturaDTO.Detalles
                    .Select(x => new DetalleFactura
                    {
                        Cantidad = x.Cantidad,
                        CodigoProducto = x.CodigoProducto,
                        NombreProducto = x.NombreProducto,
                        Precio = x.Precio,
                        SubTotal = (x.Precio * x.Cantidad)
                    })
                    .ToList();

                // Descontar stock de todos los productos seleccionados
                foreach (var item in facturaDTO.Detalles)
                {
                    await _productoService.DescontarStock(item.CodigoProducto, item.Cantidad);
                }

                var factura = new CabFactura
                {
                    ClienteId = facturaDTO.ClienteId,
                    UsuarioCreacion = facturaDTO.UsuarioCreacion!,
                    FechaCreacion = DateTime.Now,
                    Activo = true,
                    Detalles = detalles
                };

                _context.CabFacturas.Add(factura);

                await _context.SaveChangesAsync();

                var secuencial = factura.Id.ToString().PadLeft(8, '0');

                factura.NumeroFactura = $"FE-{secuencial}";

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return factura;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                return null;
            }
            
        }

        public async Task<ICollection<CabFactura>> ListarFacturas()
        {
            return await _context.CabFacturas
                .Where(f => f.Activo)
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                .ToListAsync();
        }

        public Task<CabFactura?> ObtenerFacturaPorId(int id) =>
            _context.CabFacturas
                .Include(f => f.Cliente)
                .Include(f => f.Detalles)
                .FirstOrDefaultAsync(f => f.Id == id);
    }
}
