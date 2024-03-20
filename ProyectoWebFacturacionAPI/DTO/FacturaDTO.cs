namespace ProyectoWebFacturacionAPI.DTO
{
    public class FacturaDTO
    {
        public required int ClienteId { get; set; }
        public string? UsuarioCreacion { get; set; }
        public required ICollection<DetalleFacturaDTO> Detalles { get; set; }
    }
}
