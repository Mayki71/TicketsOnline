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
    public class OrdenController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public OrdenController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenDto>>> GetAll()
        {
            var list = await _context.Ordenes.Include(o => o.Usuario).ToListAsync();
            return Ok(list.Select(o => new OrdenDto
            {
                OrdenId = o.OrdenId,
                UsuarioId = o.UsuarioId,
                UsuarioNombre = o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellido}" : null,
                FechaOrden = o.FechaOrden,
                Total = o.Total
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenDto>> Get(int id)
        {
            var o = await _context.Ordenes.Include(x => x.Usuario).FirstOrDefaultAsync(x => x.OrdenId == id);
            if (o == null) return NotFound();
            return Ok(new OrdenDto
            {
                OrdenId = o.OrdenId,
                UsuarioId = o.UsuarioId,
                UsuarioNombre = o.Usuario != null ? $"{o.Usuario.Nombre} {o.Usuario.Apellido}" : null,
                FechaOrden = o.FechaOrden,
                Total = o.Total
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(OrdenCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _context.Usuarios.AnyAsync(u => u.UsuarioId == dto.UsuarioId)) return BadRequest("UsuarioId inválido.");
            var o = new Orden { UsuarioId = dto.UsuarioId, FechaOrden = dto.FechaOrden, Total = dto.Total };
            _context.Ordenes.Add(o);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = o.OrdenId }, new { o.OrdenId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OrdenUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var o = await _context.Ordenes.FindAsync(id);
            if (o == null) return NotFound();
            if (!await _context.Usuarios.AnyAsync(u => u.UsuarioId == dto.UsuarioId)) return BadRequest("UsuarioId inválido.");
            o.UsuarioId = dto.UsuarioId;
            o.FechaOrden = dto.FechaOrden;
            o.Total = dto.Total;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var o = await _context.Ordenes.FindAsync(id);
            if (o == null) return NotFound();
            _context.Ordenes.Remove(o);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
