using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGDApi.Data;
using SGDApi.Models;

namespace SGDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElecionesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ElecionesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Eleciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elecciones>>> GetEleciones()
        {
          if (_context.Eleciones == null)
          {
              return NotFound();
          }
            return await _context.Eleciones.ToListAsync();
        }

        // GET: api/Eleciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elecciones>> GetEleciones(int id)
        {
          if (_context.Eleciones == null)
          {
              return NotFound();
          }
            var eleciones = await _context.Eleciones.FindAsync(id);

            if (eleciones == null)
            {
                return NotFound();
            }

            return eleciones;
        }

        // PUT: api/Eleciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEleciones(int id, Elecciones eleciones)
        {
            if (id != eleciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(eleciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElecionesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Eleciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Elecciones>> PostEleciones(Elecciones eleciones)
        {
          if (_context.Eleciones == null)
          {
              return Problem("Entity set 'ApiDbContext.Eleciones'  is null.");
          }
            _context.Eleciones.Add(eleciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEleciones", new { id = eleciones.Id }, eleciones);
        }

        // DELETE: api/Eleciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEleciones(int id)
        {
            if (_context.Eleciones == null)
            {
                return NotFound();
            }
            var eleciones = await _context.Eleciones.FindAsync(id);
            if (eleciones == null)
            {
                return NotFound();
            }

            _context.Eleciones.Remove(eleciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElecionesExists(int id)
        {
            return (_context.Eleciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
