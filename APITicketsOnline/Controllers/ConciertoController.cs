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
    public class ConciertoController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public ConciertoController(ConciertosContext context) => _context = context;
        [Authorize(Roles = "organizador,admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConciertoDto>>> GetAll()
        {
            var list = await _context.Conciertos
                .Include(c => c.Ciudad)
                .Include(c => c.Genero)
                .Include(c => c.Organizador)
                .ToListAsync();

            return Ok(list.Select(c => new ConciertoDto
            {
                ConciertoId = c.ConciertoId,
                Titulo = c.Titulo,
                Descripcion = c.Descripcion,
                Fecha = c.Fecha,
                CiudadId = c.CiudadId,
                CiudadNombre = c.Ciudad?.Nombre,
                GeneroId = c.GeneroId,
                GeneroNombre = c.Genero?.Nombre,
                OrganizadorId = c.OrganizadorId,
                OrganizadorNombre = c.Organizador?.NombreEmpresa
            }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConciertoDto>> Get(int id)
        {
            var c = await _context.Conciertos
                .Include(cn => cn.Ciudad)
                .Include(cn => cn.Genero)
                .Include(cn => cn.Organizador)
                .FirstOrDefaultAsync(cn => cn.ConciertoId == id);
            if (c == null) return NotFound();
            return Ok(new ConciertoDto
            {
                ConciertoId = c.ConciertoId,
                Titulo = c.Titulo,
                Descripcion = c.Descripcion,
                Fecha = c.Fecha,
                CiudadId = c.CiudadId,
                CiudadNombre = c.Ciudad?.Nombre,
                GeneroId = c.GeneroId,
                GeneroNombre = c.Genero?.Nombre,
                OrganizadorId = c.OrganizadorId,
                OrganizadorNombre = c.Organizador?.NombreEmpresa
            });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPost]
        public async Task<ActionResult> Post(ConciertoCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            // Validar fk
            if (!await _context.Ciudades.AnyAsync(x => x.CiudadId == dto.CiudadId)) return BadRequest("CiudadId inválido.");
            if (!await _context.GenerosMusicales.AnyAsync(x => x.GeneroId == dto.GeneroId)) return BadRequest("GeneroId inválido.");
            if (!await _context.Organizadores.AnyAsync(x => x.OrganizadorId == dto.OrganizadorId)) return BadRequest("OrganizadorId inválido.");

            var c = new Concierto
            {
                Titulo = dto.Titulo,
                Descripcion = dto.Descripcion,
                Fecha = dto.Fecha,
                CiudadId = dto.CiudadId,
                GeneroId = dto.GeneroId,
                OrganizadorId = dto.OrganizadorId
            };

            _context.Conciertos.Add(c);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = c.ConciertoId }, new { c.ConciertoId });
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, ConciertoUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var c = await _context.Conciertos.FindAsync(id);
            if (c == null) return NotFound();
            if (!await _context.Ciudades.AnyAsync(x => x.CiudadId == dto.CiudadId)) return BadRequest("CiudadId inválido.");
            if (!await _context.GenerosMusicales.AnyAsync(x => x.GeneroId == dto.GeneroId)) return BadRequest("GeneroId inválido.");
            if (!await _context.Organizadores.AnyAsync(x => x.OrganizadorId == dto.OrganizadorId)) return BadRequest("OrganizadorId inválido.");

            c.Titulo = dto.Titulo;
            c.Descripcion = dto.Descripcion;
            c.Fecha = dto.Fecha;
            c.CiudadId = dto.CiudadId;
            c.GeneroId = dto.GeneroId;
            c.OrganizadorId = dto.OrganizadorId;

            await _context.SaveChangesAsync();
            return Ok();
        }
        [Authorize(Roles = "organizador,admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var c = await _context.Conciertos.FindAsync(id);
            if (c == null) return NotFound();
            _context.Conciertos.Remove(c);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
