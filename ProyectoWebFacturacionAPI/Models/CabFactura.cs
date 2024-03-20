using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebFacturacionAPI.Models
{
    public class CabFactura
    {
        [Key]
        [Column("FacturaId")]
        public int Id { get; set; }
        [MaxLength(11)]
        public string? NumeroFactura { get; set; }
        [Required]
        public int ClienteId { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required]
        public required string UsuarioCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public Cliente Cliente { get; set; } = null!;

        public ICollection<DetalleFactura> Detalles { get; set; } = new List<DetalleFactura>();

    }
}
