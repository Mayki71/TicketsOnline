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
    public class PagoController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public PagoController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PagoDto>>> GetAll()
        {
            var list = await _context.Pagos.Include(p => p.Orden).ToListAsync();
            return Ok(list.Select(p => new PagoDto
            {
                PagoId = p.PagoId,
                OrdenId = p.OrdenId,
                Monto = p.Monto,
                Metodo = p.Metodo,
                Estado = p.Estado,
                FechaPago = p.FechaPago
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PagoDto>> Get(int id)
        {
            var p = await _context.Pagos.Include(x => x.Orden).FirstOrDefaultAsync(x => x.PagoId == id);
            if (p == null) return NotFound();
            return Ok(new PagoDto
            {
                PagoId = p.PagoId,
                OrdenId = p.OrdenId,
                Monto = p.Monto,
                Metodo = p.Metodo,
                Estado = p.Estado,
                FechaPago = p.FechaPago
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(PagoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _context.Ordenes.AnyAsync(o => o.OrdenId == dto.OrdenId)) return BadRequest("OrdenId inválido.");
            // Validar metodo y estado mínimos (podrías ampliar con regex si quieres)
            var p = new Pago
            {
                OrdenId = dto.OrdenId,
                Metodo = dto.Metodo,
                Ultimos4 = dto.Ultimos4,
                MarcaTarjeta = dto.MarcaTarjeta,
                Token = dto.Token,
                Monto = dto.Monto,
                Estado = dto.Estado,
                FechaPago = DateTime.UtcNow
            };
            _context.Pagos.Add(p);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = p.PagoId }, new { p.PagoId });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PagoUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var p = await _context.Pagos.FindAsync(id);
            if (p == null) return NotFound();
            p.Estado = dto.Estado;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var p = await _context.Pagos.FindAsync(id);
            if (p == null) return NotFound();
            _context.Pagos.Remove(p);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
