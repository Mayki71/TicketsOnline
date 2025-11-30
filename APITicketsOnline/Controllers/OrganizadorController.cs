using APITicketsOnline.Data;
using APITicketsOnline.Models;
using APITicketsOnline.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITicketsOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizadorController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public OrganizadorController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizadorDto>>> GetAll()
        {
            var list = await _context.Organizadores.Include(o => o.Usuario).ToListAsync();
            return Ok(list.Select(o => new OrganizadorDto
            {
                OrganizadorId = o.OrganizadorId,
                UsuarioId = o.UsuarioId,
                NombreEmpresa = o.NombreEmpresa,
                UsuarioNombre = o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellido}" : null
            }));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrganizadorDto>> Get(int id)
        {
            var o = await _context.Organizadores.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.OrganizadorId == id);
            if (o == null) return NotFound();
            return Ok(new OrganizadorDto
            {
                OrganizadorId = o.OrganizadorId,
                UsuarioId = o.UsuarioId,
                NombreEmpresa = o.NombreEmpresa,
                UsuarioNombre = o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellido}" : null
            });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPost]
        public async Task<ActionResult> Post(OrganizadorCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var user = await _context.Usuarios.FindAsync(dto.UsuarioId);
            if (user == null) return BadRequest("UsuarioId inválido.");
            var org = new Organizador { UsuarioId = dto.UsuarioId, NombreEmpresa = dto.NombreEmpresa };
            _context.Organizadores.Add(org);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = org.OrganizadorId }, new { org.OrganizadorId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OrganizadorUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var org = await _context.Organizadores.FindAsync(id);
            if (org == null) return NotFound();
            var user = await _context.Usuarios.FindAsync(dto.UsuarioId);
            if (user == null) return BadRequest("UsuarioId inválido.");
            org.UsuarioId = dto.UsuarioId;
            org.NombreEmpresa = dto.NombreEmpresa;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var org = await _context.Organizadores.FindAsync(id);
            if (org == null) return NotFound();
            _context.Organizadores.Remove(org);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
