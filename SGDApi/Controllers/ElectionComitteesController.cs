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
    public class ElectionComitteesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ElectionComitteesController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/ElectionComittees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectionComittee>>> GetElectionComittee()
        {
          if (_context.ElectionComittee == null)
          {
              return NotFound();
          }
            return await _context.ElectionComittee.ToListAsync();
        }

        // GET: api/ElectionComittees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectionComittee>> GetElectionComittee(int id)
        {
          if (_context.ElectionComittee == null)
          {
              return NotFound();
          }
            var electionComittee = await _context.ElectionComittee.FindAsync(id);

            if (electionComittee == null)
            {
                return NotFound();
            }

            return electionComittee;
        }

        // PUT: api/ElectionComittees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectionComittee(int id, ElectionComittee electionComittee)
        {
            if (id != electionComittee.Id)
            {
                return BadRequest();
            }

            _context.Entry(electionComittee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectionComitteeExists(id))
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

        // POST: api/ElectionComittees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ElectionComittee>> PostElectionComittee(ElectionComittee electionComittee)
        {
          if (_context.ElectionComittee == null)
          {
              return Problem("Entity set 'ApiDbContext.ElectionComittee'  is null.");
          }
            _context.ElectionComittee.Add(electionComittee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectionComittee", new { id = electionComittee.Id }, electionComittee);
        }

        // DELETE: api/ElectionComittees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectionComittee(int id)
        {
            if (_context.ElectionComittee == null)
            {
                return NotFound();
            }
            var electionComittee = await _context.ElectionComittee.FindAsync(id);
            if (electionComittee == null)
            {
                return NotFound();
            }

            _context.ElectionComittee.Remove(electionComittee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectionComitteeExists(int id)
        {
            return (_context.ElectionComittee?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
