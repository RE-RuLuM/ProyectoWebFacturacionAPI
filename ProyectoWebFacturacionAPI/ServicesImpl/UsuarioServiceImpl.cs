using Microsoft.EntityFrameworkCore;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Models;
using ProyectoWebFacturacionAPI.Services;
using System.Collections.ObjectModel;

namespace ProyectoWebFacturacionAPI.ServicesImpl
{
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly ApplicationDBContext _context;
        public UsuarioServiceImpl(ApplicationDBContext context)
        {
            _context = context;
        }
        public Task<int> ActualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<int> EliminarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> ObtenerUsuarioPorUsername(string username)
        {
            return _context.Usuarios.Where(x => x.Username == username).FirstAsync();
        }

        public Task<Collection<Usuario>> ObtenerUsuarios()
        {
            throw new NotImplementedException();
        }

        public Task<int> RegistrarUsuario(UsuarioDTO usuarioReq)
        {

            var usuario = new Usuario
            {
                Nombres = usuarioReq.Nombres,
                Apellidos = usuarioReq.Apellidos,
                DNI = usuarioReq.DNI,
                Username = usuarioReq.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(usuarioReq.Password),
                Activo = true,
                FechaCreacion = DateTime.Now,
                UsuarioCreacion = usuarioReq.UsuarioCreacion!
            };

            _context.Usuarios.Add(usuario);
            return _context.SaveChangesAsync();
        }
    }
}
