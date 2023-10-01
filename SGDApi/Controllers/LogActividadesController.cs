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
    public class LogActividadesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public LogActividadesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/LogActividades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogActividades>>> GetLogActividades()
        {
          if (_context.LogActividades == null)
          {
              return NotFound();
          }
            return await _context.LogActividades.ToListAsync();
        }

        // GET: api/LogActividades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogActividades>> GetLogActividades(int id)
        {
          if (_context.LogActividades == null)
          {
              return NotFound();
          }
            var logActividades = await _context.LogActividades.FindAsync(id);

            if (logActividades == null)
            {
                return NotFound();
            }

            return logActividades;
        }

        // PUT: api/LogActividades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogActividades(int id, LogActividades logActividades)
        {
            if (id != logActividades.LogActividadId)
            {
                return BadRequest();
            }

            _context.Entry(logActividades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogActividadesExists(id))
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

        // POST: api/LogActividades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogActividades>> PostLogActividades(LogActividades logActividades)
        {
          if (_context.LogActividades == null)
          {
              return Problem("Entity set 'ApiDbContext.LogActividades'  is null.");
          }
            _context.LogActividades.Add(logActividades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogActividades", new { id = logActividades.LogActividadId }, logActividades);
        }

        // DELETE: api/LogActividades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogActividades(int id)
        {
            if (_context.LogActividades == null)
            {
                return NotFound();
            }
            var logActividades = await _context.LogActividades.FindAsync(id);
            if (logActividades == null)
            {
                return NotFound();
            }

            _context.LogActividades.Remove(logActividades);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogActividadesExists(int id)
        {
            return (_context.LogActividades?.Any(e => e.LogActividadId == id)).GetValueOrDefault();
        }
    }
}
