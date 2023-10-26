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
    public class PartidoPoliticoesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public PartidoPoliticoesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/PartidoPoliticoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartidoPolitico>>> GetPartidoPolitico()
        {
          if (_context.PartidoPolitico == null)
          {
              return NotFound();
          }
            return await _context.PartidoPolitico.ToListAsync();
        }

        // GET: api/PartidoPoliticoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PartidoPolitico>> GetPartidoPolitico(int id)
        {
          if (_context.PartidoPolitico == null)
          {
              return NotFound();
          }
            var partidoPolitico = await _context.PartidoPolitico.FindAsync(id);

            if (partidoPolitico == null)
            {
                return NotFound();
            }

            return partidoPolitico;
        }

        // PUT: api/PartidoPoliticoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPartidoPolitico(int id, PartidoPolitico partidoPolitico)
        {
            if (id != partidoPolitico.Id)
            {
                return BadRequest();
            }

            _context.Entry(partidoPolitico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartidoPoliticoExists(id))
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

        // POST: api/PartidoPoliticoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PartidoPolitico>> PostPartidoPolitico(PartidoPolitico partidoPolitico)
        {
          if (_context.PartidoPolitico == null)
          {
              return Problem("Entity set 'ApiDbContext.PartidoPolitico'  is null.");
          }
            _context.PartidoPolitico.Add(partidoPolitico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPartidoPolitico", new { id = partidoPolitico.Id }, partidoPolitico);
        }

        // DELETE: api/PartidoPoliticoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePartidoPolitico(int id)
        {
            if (_context.PartidoPolitico == null)
            {
                return NotFound();
            }
            var partidoPolitico = await _context.PartidoPolitico.FindAsync(id);
            if (partidoPolitico == null)
            {
                return NotFound();
            }

            _context.PartidoPolitico.Remove(partidoPolitico);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PartidoPoliticoExists(int id)
        {
            return (_context.PartidoPolitico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
