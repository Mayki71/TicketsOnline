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
    public class EntradaController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public EntradaController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntradaDto>>> GetAll()
        {
            var list = await _context.Entradas
                .Include(e => e.TipoEntrada)
                .ToListAsync();

            return Ok(list.Select(e => new EntradaDto
            {
                EntradaId = e.EntradaId,
                OrdenId = e.OrdenId,
                TipoId = e.TipoId,
                TipoNombre = e.TipoEntrada?.Nombre,
                Precio = e.TipoEntrada?.Precio ?? 0,
                CodigoQr = e.CodigoQr,
                Estado = e.Estado
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntradaDto>> Get(int id)
        {
            var e = await _context.Entradas.Include(x => x.TipoEntrada).FirstOrDefaultAsync(x => x.EntradaId == id);
            if (e == null) return NotFound();
            return Ok(new EntradaDto
            {
                EntradaId = e.EntradaId,
                OrdenId = e.OrdenId,
                TipoId = e.TipoId,
                TipoNombre = e.TipoEntrada?.Nombre,
                Precio = e.TipoEntrada?.Precio ?? 0,
                CodigoQr = e.CodigoQr,
                Estado = e.Estado
            });
        }

        [HttpPost]
        public async Task<ActionResult> Post(EntradaCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!await _context.Ordenes.AnyAsync(o => o.OrdenId == dto.OrdenId)) return BadRequest("OrdenId inválido.");
            if (!await _context.TiposDeEntrada.AnyAsync(t => t.TipoId == dto.TipoId)) return BadRequest("TipoId inválido.");

            var entrada = new Entrada
            {
                OrdenId = dto.OrdenId,
                TipoId = dto.TipoId,
                CodigoQr = dto.CodigoQr,
                Estado = dto.Estado
            };

            _context.Entradas.Add(entrada);

            // Si quieres decrementar stock del tipo de entrada:
            var tipo = await _context.TiposDeEntrada.FindAsync(dto.TipoId);
            if (tipo != null)
            {
                if (tipo.Stock <= 0) return BadRequest("Stock insuficiente.");
                tipo.Stock -= 1;
            }

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = entrada.EntradaId }, new { entrada.EntradaId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, EntradaUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var e = await _context.Entradas.FindAsync(id);
            if (e == null) return NotFound();
            if (!await _context.TiposDeEntrada.AnyAsync(t => t.TipoId == dto.TipoId)) return BadRequest("TipoId inválido.");
            e.TipoId = dto.TipoId;
            e.CodigoQr = dto.CodigoQr;
            e.Estado = dto.Estado;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var e = await _context.Entradas.FindAsync(id);
            if (e == null) return NotFound();

            // Opcional: al eliminar, puedes incrementar stock del tipo asociado
            var tipo = await _context.TiposDeEntrada.FindAsync(e.TipoId);
            if (tipo != null) tipo.Stock += 1;

            _context.Entradas.Remove(e);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
