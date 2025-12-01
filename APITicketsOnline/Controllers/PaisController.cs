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
    public class PaisController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public PaisController(ConciertosContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaisDto>>> GetAll()
        {
            var list = await _context.Paises.ToListAsync();
            var dtos = list.Select(p => new PaisDto { PaisId = p.PaisId, Nombre = p.Nombre });
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaisDto>> Get(int id)
        {
            var p = await _context.Paises.FindAsync(id);
            if (p == null) return NotFound();
            return Ok(new PaisDto { PaisId = p.PaisId, Nombre = p.Nombre });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPost]
        public async Task<ActionResult> Post(PaisCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var pais = new Pais { Nombre = dto.Nombre };
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = pais.PaisId }, new { pais.PaisId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, PaisUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null) return NotFound();
            pais.Nombre = dto.Nombre;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null) return NotFound();
            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
