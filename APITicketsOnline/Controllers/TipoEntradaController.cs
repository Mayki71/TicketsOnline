using APITicketsOnline.Data;
using APITicketsOnline.Models;
using APITicketsOnline.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APITicketsOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEntradaController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public TipoEntradaController(ConciertosContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoEntradaDto>>> GetAll()
        {
            var list = await _context.TiposDeEntrada.Include(t => t.Concierto).ToListAsync();
            return Ok(list.Select(t => new TipoEntradaDto
            {
                TipoId = t.TipoId,
                ConciertoId = t.ConciertoId,
                ConciertoTitulo = t.Concierto?.Titulo,
                Nombre = t.Nombre,
                Precio = t.Precio,
                Stock = t.Stock
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TipoEntradaDto>> Get(int id)
        {
            var t = await _context.TiposDeEntrada.Include(x => x.Concierto).FirstOrDefaultAsync(x => x.TipoId == id);
            if (t == null) return NotFound();
            return Ok(new TipoEntradaDto
            {
                TipoId = t.TipoId,
                ConciertoId = t.ConciertoId,
                ConciertoTitulo = t.Concierto?.Titulo,
                Nombre = t.Nombre,
                Precio = t.Precio,
                Stock = t.Stock
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoEntradaCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _context.Conciertos.AnyAsync(c => c.ConciertoId == dto.ConciertoId)) return BadRequest("ConciertoId inválido.");
            var t = new TipoEntrada
            {
                ConciertoId = dto.ConciertoId,
                Nombre = dto.Nombre,
                Precio = dto.Precio,
                Stock = dto.Stock
            };
            _context.TiposDeEntrada.Add(t);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = t.TipoId }, new { t.TipoId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TipoEntradaUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var t = await _context.TiposDeEntrada.FindAsync(id);
            if (t == null) return NotFound();
            if (!await _context.Conciertos.AnyAsync(c => c.ConciertoId == dto.ConciertoId)) return BadRequest("ConciertoId inválido.");
            t.ConciertoId = dto.ConciertoId;
            t.Nombre = dto.Nombre;
            t.Precio = dto.Precio;
            t.Stock = dto.Stock;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var t = await _context.TiposDeEntrada.FindAsync(id);
            if (t == null) return NotFound();
            _context.TiposDeEntrada.Remove(t);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
