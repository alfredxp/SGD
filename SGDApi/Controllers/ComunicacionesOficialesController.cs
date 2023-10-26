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
    public class ComunicacionesOficialesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ComunicacionesOficialesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ComunicacionesOficiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComunicacionesOficiales>>> GetComunicacionesOficiales()
        {
          if (_context.ComunicacionesOficiales == null)
          {
              return NotFound();
          }
            return await _context.ComunicacionesOficiales.ToListAsync();
        }

        // GET: api/ComunicacionesOficiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ComunicacionesOficiales>> GetComunicacionesOficiales(int id)
        {
          if (_context.ComunicacionesOficiales == null)
          {
              return NotFound();
          }
            var comunicacionesOficiales = await _context.ComunicacionesOficiales.FindAsync(id);

            if (comunicacionesOficiales == null)
            {
                return NotFound();
            }

            return comunicacionesOficiales;
        }

        // PUT: api/ComunicacionesOficiales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComunicacionesOficiales(int id, ComunicacionesOficiales comunicacionesOficiales)
        {
            if (id != comunicacionesOficiales.Id)
            {
                return BadRequest();
            }

            _context.Entry(comunicacionesOficiales).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunicacionesOficialesExists(id))
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

        // POST: api/ComunicacionesOficiales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ComunicacionesOficiales>> PostComunicacionesOficiales(ComunicacionesOficiales comunicacionesOficiales)
        {
          if (_context.ComunicacionesOficiales == null)
          {
              return Problem("Entity set 'ApiDbContext.ComunicacionesOficiales'  is null.");
          }
            _context.ComunicacionesOficiales.Add(comunicacionesOficiales);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComunicacionesOficiales", new { id = comunicacionesOficiales.Id }, comunicacionesOficiales);
        }

        // DELETE: api/ComunicacionesOficiales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComunicacionesOficiales(int id)
        {
            if (_context.ComunicacionesOficiales == null)
            {
                return NotFound();
            }
            var comunicacionesOficiales = await _context.ComunicacionesOficiales.FindAsync(id);
            if (comunicacionesOficiales == null)
            {
                return NotFound();
            }

            _context.ComunicacionesOficiales.Remove(comunicacionesOficiales);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunicacionesOficialesExists(int id)
        {
            return (_context.ComunicacionesOficiales?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
