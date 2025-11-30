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
    public class RolController : ControllerBase
    {
        private readonly ConciertosContext _context;
        public RolController(ConciertosContext context) => _context = context;

        [HttpGet]
        [Authorize(Roles = "organizador,admin")]
        public async Task<ActionResult<IEnumerable<RolDto>>> GetAll()
        {
            var list = await _context.Roles.ToListAsync();
            return Ok(list.Select(r => new RolDto { RolId = r.RolId, Nombre = r.Nombre, Descripcion = r.Descripcion }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RolDto>> Get(int id)
        {
            var r = await _context.Roles.FindAsync(id);
            if (r == null) return NotFound();
            return Ok(new RolDto { RolId = r.RolId, Nombre = r.Nombre, Descripcion = r.Descripcion });
        }

        [HttpPost]
        public ActionResult BlockPost() => BadRequest("No está permitido crear roles.");

        [HttpPut("{id}")]
        public ActionResult BlockPut() => BadRequest("No está permitido editar roles.");

        [HttpDelete("{id}")]
        public ActionResult BlockDelete() => BadRequest("No está permitido eliminar roles.");
    }
}
