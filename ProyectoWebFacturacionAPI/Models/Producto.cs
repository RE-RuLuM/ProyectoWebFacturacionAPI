using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebFacturacionAPI.Models
{
    [Index(nameof(Codigo), IsUnique = true)]
    public class Producto
    {
        [Key]
        [Column("ProductoId")]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public required string Codigo { get; set; }
        [Required]
        public required string Nombre { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public double Precio { get; set; }
        [Required]
        public int Stock { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
