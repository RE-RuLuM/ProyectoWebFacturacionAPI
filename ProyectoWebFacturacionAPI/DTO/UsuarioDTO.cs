namespace ProyectoWebFacturacionAPI.DTO
{
    public class UsuarioDTO
    {
        public required string DNI { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }
        public required string Username { get; set; }
        public string? Password { get; set; }
        public string? UsuarioCreacion { get; set; }
    }
}
