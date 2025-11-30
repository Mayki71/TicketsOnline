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
    public class GeneroController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public GeneroController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneroDto>>> GetAll()
        {
            var list = await _context.GenerosMusicales.ToListAsync();
            return Ok(list.Select(g => new GeneroDto { GeneroId = g.GeneroId, Nombre = g.Nombre }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GeneroDto>> Get(int id)
        {
            var g = await _context.GenerosMusicales.FindAsync(id);
            if (g == null) return NotFound();
            return Ok(new GeneroDto { GeneroId = g.GeneroId, Nombre = g.Nombre });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPost]
        public async Task<ActionResult> Post(GeneroCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var g = new GeneroMusical { Nombre = dto.Nombre };
            _context.GenerosMusicales.Add(g);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = g.GeneroId }, new { g.GeneroId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, GeneroUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var g = await _context.GenerosMusicales.FindAsync(id);
            if (g == null) return NotFound();
            g.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var g = await _context.GenerosMusicales.FindAsync(id);
            if (g == null) return NotFound();
            _context.GenerosMusicales.Remove(g);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
