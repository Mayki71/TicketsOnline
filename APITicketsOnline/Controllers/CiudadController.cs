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
    public class CiudadController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public CiudadController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CiudadDto>>> GetCiudades()
        {
            var ciudades = await _context.Ciudades.Include(c => c.Pais).ToListAsync();

            var ciudadesDto = ciudades.Select(c => new CiudadDto
            {
                CiudadId = c.CiudadId,
                Nombre = c.Nombre,
                PaisId = c.PaisId,
                PaisNombre = c.Pais?.Nombre
            });

            return Ok(ciudadesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CiudadDto>> Get(int id)
        {
            var c = await _context.Ciudades.Include(x => x.Pais).FirstOrDefaultAsync(x => x.CiudadId == id);
            if (c == null) return NotFound();
            return Ok(new CiudadDto
            {
                CiudadId = c.CiudadId,
                Nombre = c.Nombre,
                PaisId = c.PaisId,
                PaisNombre = c.Pais?.Nombre
            });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPost]
        public async Task<ActionResult> Post(CiudadCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var pais = await _context.Paises.FindAsync(dto.PaisId);
            if (pais == null) return BadRequest("PaisId inválido.");
            var ciudad = new Ciudad { Nombre = dto.Nombre, PaisId = dto.PaisId };
            _context.Ciudades.Add(ciudad);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ciudad.CiudadId }, new { ciudad.CiudadId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CiudadUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null) return NotFound();
            var pais = await _context.Paises.FindAsync(dto.PaisId);
            if (pais == null) return BadRequest("PaisId inválido.");
            ciudad.Nombre = dto.Nombre;
            ciudad.PaisId = dto.PaisId;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var ciudad = await _context.Ciudades.FindAsync(id);
            if (ciudad == null) return NotFound();
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
