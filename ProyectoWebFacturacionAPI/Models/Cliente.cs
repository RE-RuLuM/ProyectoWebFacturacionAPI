using System.ComponentModel.DataAnnotations;

namespace ProyectoWebFacturacionAPI.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public required string RucDni { get; set; }
        [Required]
        public required string Nombres { get; set; }
        [Required]
        public required string Direccion { get; set; }
        [Required]
        public required string Correo { get; set; }
        [Required]
        public bool Activo { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
