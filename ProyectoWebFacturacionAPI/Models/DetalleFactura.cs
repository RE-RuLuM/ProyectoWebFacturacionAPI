using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebFacturacionAPI.Models
{
    public class DetalleFactura
    {
        [Key]
        [Column("ItemId")]
        public int Id { get; set; }
        [Required]
        public int FacturaId { get; set; }
        [Required]
        [MaxLength(15)]
        public required string CodigoProducto { get; set; }
        [Required]
        public required string NombreProducto { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public required double Precio { get; set; }
        [Required]
        public required int Cantidad { get; set; }
        [Required]
        public required double SubTotal { get; set; }

        public CabFactura CabFactura { get; set; } = null!;
    }
}
