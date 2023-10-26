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
    public class VotingRecordsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public VotingRecordsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/VotingRecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VotingRecord>>> GetVotingRecord()
        {
          if (_context.VotingRecord == null)
          {
              return NotFound();
          }
            return await _context.VotingRecord.ToListAsync();
        }

        // GET: api/VotingRecords/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VotingRecord>> GetVotingRecord(int id)
        {
          if (_context.VotingRecord == null)
          {
              return NotFound();
          }
            var votingRecord = await _context.VotingRecord.FindAsync(id);

            if (votingRecord == null)
            {
                return NotFound();
            }

            return votingRecord;
        }

        // PUT: api/VotingRecords/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVotingRecord(int id, VotingRecord votingRecord)
        {
            if (id != votingRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(votingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotingRecordExists(id))
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

        // POST: api/VotingRecords
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VotingRecord>> PostVotingRecord(VotingRecord votingRecord)
        {
          if (_context.VotingRecord == null)
          {
              return Problem("Entity set 'ApiDbContext.VotingRecord'  is null.");
          }
            _context.VotingRecord.Add(votingRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVotingRecord", new { id = votingRecord.Id }, votingRecord);
        }

        // DELETE: api/VotingRecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVotingRecord(int id)
        {
            if (_context.VotingRecord == null)
            {
                return NotFound();
            }
            var votingRecord = await _context.VotingRecord.FindAsync(id);
            if (votingRecord == null)
            {
                return NotFound();
            }

            _context.VotingRecord.Remove(votingRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotingRecordExists(int id)
        {
            return (_context.VotingRecord?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
