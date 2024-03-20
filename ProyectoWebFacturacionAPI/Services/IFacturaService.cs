using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Utils.Responses;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IFacturaService
    {
        public Task<ResponseResource<CabFactura>> EmitirFactura(FacturaDTO facturaDTO);
        public Task<ICollection<CabFactura>> ListarFacturas();
        public Task<int> EliminarFactura(int id);
    }
}
