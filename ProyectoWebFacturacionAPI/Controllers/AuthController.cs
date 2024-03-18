using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
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
        public AuthController(IConfiguration configuration, IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO req)
        {
            var usuario = await _usuarioService.ObtenerUsuarioPorUsername(req.Username);

            bool isValidPassword = BCrypt.Net.BCrypt.Verify(req.Password, usuario.Password);

            if (!isValidPassword || usuario is null)
                return Unauthorized();
            
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
