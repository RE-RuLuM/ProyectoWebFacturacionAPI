using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebFacturacionAPI.Models
{
    public class CabFactura
    {
        [Key]
        [Column("FacturaId")]
        public int Id { get; set; }
        [Required]
        [MaxLength(11)]
        public required string NumeroFactura { get; set; }
        [Required]
        public int ClienteId { get; set; }

        public required Cliente Cliente { get; set; }

    }
}
