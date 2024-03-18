using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using System.Collections.ObjectModel;

namespace ProyectoWebFacturacionAPI.Services
{
    public interface IUsuarioService
    {
        public Task<Collection<Usuario>> ObtenerUsuarios();
        public Task<Usuario> ObtenerUsuarioPorUsername(string username);
        public Task<int> RegistrarUsuario(UsuarioDTO usuario);
        public Task<int> ActualizarUsuario(Usuario usuario);
        public Task<int> EliminarUsuario(int id);
    }
}
