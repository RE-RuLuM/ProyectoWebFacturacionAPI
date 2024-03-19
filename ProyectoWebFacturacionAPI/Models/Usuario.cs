using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWebFacturacionAPI.Models
{
    [Index(nameof(Username), IsUnique = true)]
    public class Usuario
    {
        [Key]
        [Column("UsuarioId")]
        public int Id { get; set; }
        [Required]
        public required string Nombres { get; set; }
        [Required]
        public required string Apellidos { get; set; }
        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        public required string DNI { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        [DefaultValue(0)]
        public int NumeroIntentos { get; set; }
        public DateTime? FechaBloqueoLogin { get; set; }
        [Required]
        public required bool Activo { get; set; }
        [Required]
        public required DateTime FechaCreacion { get; set; }
        [Required]
        public required string UsuarioCreacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
