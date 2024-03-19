using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProyectoWebFacturacionAPI.Data;
using ProyectoWebFacturacionAPI.DTO;
using ProyectoWebFacturacionAPI.Services;
using ProyectoWebFacturacionAPI.Utils;
using System.Security.Claims;

namespace ProyectoWebFacturacionAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;
        private readonly ApplicationDBContext _context;
        public AuthController(IConfiguration configuration, IUsuarioService usuarioService, ApplicationDBContext context)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO req)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorUsername(req.Username);

            if (usuario is null)
                return Unauthorized();

            // Despues de mas de 5 intentos bloquear usuario por 1 min
            if (usuario.NumeroIntentos > 5 && usuario.FechaBloqueoLogin is null)
            {
                usuario.FechaBloqueoLogin = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            // Si no ha pasado 1 min, no se le permite ingresar
            if (usuario.FechaBloqueoLogin is not null)
            {
                TimeSpan timePassed = DateTime.Now.Subtract((DateTime) usuario.FechaBloqueoLogin);
                if (timePassed.TotalMinutes > 1)
                {
                    // Reset numero intentos
                    usuario.FechaBloqueoLogin = null;
                    usuario.NumeroIntentos = 0;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    return Unauthorized();
                }
            }

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(req.Password, usuario.Password);

            // Si se equivoca aumenta el numero de intentos en 1 
            if (!isValidPassword)
            {
                usuario.NumeroIntentos++;
                await _context.SaveChangesAsync();
                return Unauthorized();
            }
            
            var token = TokenUtils.GenerateToken(usuario, _configuration["Jwt:SecretKey"] ?? "");

            return Ok(token);
        }

        [Authorize]
        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(UsuarioDTO usuarioReq)
        {
            usuarioReq.UsuarioCreacion = User?.Identity?.Name;
            int result = await _usuarioService.RegistrarUsuario(usuarioReq);

            if (result == 0)
                return Problem();

            return Created();
        }
    }
}
