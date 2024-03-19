using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProyectoWebFacturacionAPI.DTO
{
    public class ProductoDTO
    {
        public int? Id { get; set; }
        public required string Codigo { get; set; }
        public required string Nombre { get; set; }
        public required double Precio { get; set; }
        public required int Stock { get; set; }
    }
}
