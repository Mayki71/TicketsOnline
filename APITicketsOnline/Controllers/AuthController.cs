using APITicketsOnline.Data;
using APITicketsOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APITicketsOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ConciertosContext _context;
        private readonly IConfiguration _config;

        public AuthController(ConciertosContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // POST: api/Auth/login (RUTA PÚBLICA)
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            // 1. Verificar el usuario y obtener su rol
            // Nota: En un sistema real, aquí se verificaría la contraseña HASH.
            var usuario = await _context.Usuarios
                .Include(u => u.Rol)
                .SingleOrDefaultAsync(u => u.Email == login.Email && u.PasswordHash == login.Password);

            if (usuario == null)
            {
                return Unauthorized(new { message = "Credenciales inválidas." });
            }

            // 2. Generar el Token
            var token = GenerarToken(usuario);

            return Ok(new { token = token });
        }

        private string GenerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
    {
        // Identificador único del usuario (obligatorio)
        new Claim(ClaimTypes.NameIdentifier, usuario.UsuarioId.ToString()),
        new Claim(ClaimTypes.Name, usuario.Email),
        
        // Rol del usuario (MUY IMPORTANTE para la autorización)
        new Claim(ClaimTypes.Role, usuario.Rol?.Nombre ?? "usuario_sin_rol")
    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expirationMinutes = double.Parse(_config["Jwt:DurationMinutes"] ?? "60");

            // 🚨 FIX CRÍTICO: Usar UTC para evitar errores de zona horaria 🚨
            var now = DateTime.UtcNow;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),

                // Establecemos explícitamente la hora de inicio y expiración usando UTC
                IssuedAt = now,
                NotBefore = now,
                Expires = now.AddMinutes(expirationMinutes),

                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
