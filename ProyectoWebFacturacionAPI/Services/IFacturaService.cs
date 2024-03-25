using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Utils.Responses;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IFacturaService
    {
        public Task<CabFactura> EmitirFactura(FacturaDTO facturaDTO);
        public Task<ICollection<CabFactura>> ListarFacturas();
        public Task<CabFactura> ObtenerFacturaPorId(int id);
        public Task<int> EliminarFactura(int id);
    }
}
