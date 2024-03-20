namespace ProyectoWebFacturacionAPI.DTO
{
    public class DetalleFacturaDTO
    {
        public required string CodigoProducto { get; set; }
        public required string NombreProducto { get; set; }
        public required double Precio { get; set; }
        public required int Cantidad { get; set; }
    }
}
