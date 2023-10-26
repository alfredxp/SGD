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
    public class CalendarioEleccionesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CalendarioEleccionesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/CalendarioElecciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarioElecciones>>> GetCalendarioElecciones()
        {
          if (_context.CalendarioElecciones == null)
          {
              return NotFound();
          }
            return await _context.CalendarioElecciones.ToListAsync();
        }

        // GET: api/CalendarioElecciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarioElecciones>> GetCalendarioElecciones(int id)
        {
          if (_context.CalendarioElecciones == null)
          {
              return NotFound();
          }
            var calendarioElecciones = await _context.CalendarioElecciones.FindAsync(id);

            if (calendarioElecciones == null)
            {
                return NotFound();
            }

            return calendarioElecciones;
        }

        // PUT: api/CalendarioElecciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarioElecciones(int id, CalendarioElecciones calendarioElecciones)
        {
            if (id != calendarioElecciones.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendarioElecciones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarioEleccionesExists(id))
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

        // POST: api/CalendarioElecciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalendarioElecciones>> PostCalendarioElecciones(CalendarioElecciones calendarioElecciones)
        {
          if (_context.CalendarioElecciones == null)
          {
              return Problem("Entity set 'ApiDbContext.CalendarioElecciones'  is null.");
          }
            _context.CalendarioElecciones.Add(calendarioElecciones);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarioElecciones", new { id = calendarioElecciones.Id }, calendarioElecciones);
        }

        // DELETE: api/CalendarioElecciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarioElecciones(int id)
        {
            if (_context.CalendarioElecciones == null)
            {
                return NotFound();
            }
            var calendarioElecciones = await _context.CalendarioElecciones.FindAsync(id);
            if (calendarioElecciones == null)
            {
                return NotFound();
            }

            _context.CalendarioElecciones.Remove(calendarioElecciones);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CalendarioEleccionesExists(int id)
        {
            return (_context.CalendarioElecciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
