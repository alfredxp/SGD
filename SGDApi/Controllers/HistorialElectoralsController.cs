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
    public class HistorialElectoralsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public HistorialElectoralsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/HistorialElectorals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialElectoral>>> GetHistorialElectoral()
        {
          if (_context.HistorialElectoral == null)
          {
              return NotFound();
          }
            return await _context.HistorialElectoral.ToListAsync();
        }

        // GET: api/HistorialElectorals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialElectoral>> GetHistorialElectoral(int id)
        {
          if (_context.HistorialElectoral == null)
          {
              return NotFound();
          }
            var historialElectoral = await _context.HistorialElectoral.FindAsync(id);

            if (historialElectoral == null)
            {
                return NotFound();
            }

            return historialElectoral;
        }

        // PUT: api/HistorialElectorals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialElectoral(int id, HistorialElectoral historialElectoral)
        {
            if (id != historialElectoral.Id)
            {
                return BadRequest();
            }

            _context.Entry(historialElectoral).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialElectoralExists(id))
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

        // POST: api/HistorialElectorals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialElectoral>> PostHistorialElectoral(HistorialElectoral historialElectoral)
        {
          if (_context.HistorialElectoral == null)
          {
              return Problem("Entity set 'ApiDbContext.HistorialElectoral'  is null.");
          }
            _context.HistorialElectoral.Add(historialElectoral);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHistorialElectoral", new { id = historialElectoral.Id }, historialElectoral);
        }

        // DELETE: api/HistorialElectorals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialElectoral(int id)
        {
            if (_context.HistorialElectoral == null)
            {
                return NotFound();
            }
            var historialElectoral = await _context.HistorialElectoral.FindAsync(id);
            if (historialElectoral == null)
            {
                return NotFound();
            }

            _context.HistorialElectoral.Remove(historialElectoral);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialElectoralExists(int id)
        {
            return (_context.HistorialElectoral?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
