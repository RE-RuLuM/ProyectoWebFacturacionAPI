
namespace ProyectoWebFacturacionAPI.DTO
{
    public class ClienteDTO
    {
        public int? Id { get; set; }
        public required string RucDni { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Direccion { get; set; }
        public required string Correo { get; set; }
    }
}
