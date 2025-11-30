using APITicketsOnline.Data;
using APITicketsOnline.Models;
using APITicketsOnline.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace APITicketsOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public UsuariosController(ConciertosContext context) => _context = context;

        // Hash helper (SHA256 -> Base64) como en tu ejemplo
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        // GET: api/Usuarios
        [HttpGet]
        [Authorize(Roles = "organizador,admin")]
        public async Task<ActionResult<IEnumerable<UsuarioDto>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Rol).ToListAsync();
            var dtos = usuarios.Select(u => new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Telefono = u.Telefono,
                Estado = u.Estado,
                FechaRegistro = u.FechaRegistro,
                RolId = u.RolId,
                RolNombre = u.Rol?.Nombre
            });
            return Ok(dtos);
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]

        public async Task<ActionResult<UsuarioDto>> GetUsuario(int id)
        {
            var u = await _context.Usuarios.Include(r => r.Rol).FirstOrDefaultAsync(x => x.UsuarioId == id);
            if (u == null) return NotFound();
            var dto = new UsuarioDto
            {
                UsuarioId = u.UsuarioId,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email,
                Telefono = u.Telefono,
                Estado = u.Estado,
                FechaRegistro = u.FechaRegistro,
                RolId = u.RolId,
                RolNombre = u.Rol?.Nombre
            };
            return Ok(dto);
        }

        // POST: api/Usuarios
        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> PostUsuario([FromBody] UsuarioCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Validar email único
            if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email))
                return BadRequest("Email ya registrado.");

            // Validar rol existe
            var rol = await _context.Roles.FindAsync(dto.RolId);
            if (rol == null) return BadRequest("RolId inválido.");

            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Estado = dto.Estado ?? true,
                FechaRegistro = DateTime.UtcNow,
                RolId = dto.RolId,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            var outDto = new UsuarioDto
            {
                UsuarioId = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                Telefono = usuario.Telefono,
                Estado = usuario.Estado,
                FechaRegistro = usuario.FechaRegistro,
                RolId = usuario.RolId,
                RolNombre = rol.Nombre
            };

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.UsuarioId }, outDto);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        [Authorize(Roles = "organizador,admin")]
        public async Task<IActionResult> PutUsuario(int id, [FromBody] UsuarioUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _context.Usuarios.FindAsync(id);
            if (user == null) return NotFound();

            // Si email cambia, verificar unicidad
            if (!string.Equals(user.Email, dto.Email, StringComparison.OrdinalIgnoreCase))
            {
                if (await _context.Usuarios.AnyAsync(u => u.Email == dto.Email && u.UsuarioId != id))
                    return BadRequest("Email ya en uso por otro usuario.");
            }

            // Validar rol
            var rol = await _context.Roles.FindAsync(dto.RolId);
            if (rol == null) return BadRequest("RolId inválido.");

            user.Nombre = dto.Nombre;
            user.Apellido = dto.Apellido;
            user.Email = dto.Email;
            user.Telefono = dto.Telefono;
            user.Estado = dto.Estado;
            // Solo admin puede cambiar rol efectivamente
            if (User.IsInRole("admin"))
                user.RolId = dto.RolId;

            if (!string.IsNullOrEmpty(dto.Password))
                user.PasswordHash = HashPassword(dto.Password);

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var u = await _context.Usuarios.FindAsync(id);
            if (u == null) return NotFound();
            _context.Usuarios.Remove(u);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool UsuarioExists(int id) => _context.Usuarios.Any(e => e.UsuarioId == id);
    }
}
