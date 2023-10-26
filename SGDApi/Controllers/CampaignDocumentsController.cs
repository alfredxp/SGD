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
    public class CampaignDocumentsController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public CampaignDocumentsController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/CampaignDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampaignDocument>>> GetCampaignDocument()
        {
          if (_context.CampaignDocument == null)
          {
              return NotFound();
          }
            return await _context.CampaignDocument.ToListAsync();
        }

        // GET: api/CampaignDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampaignDocument>> GetCampaignDocument(int id)
        {
          if (_context.CampaignDocument == null)
          {
              return NotFound();
          }
            var campaignDocument = await _context.CampaignDocument.FindAsync(id);

            if (campaignDocument == null)
            {
                return NotFound();
            }

            return campaignDocument;
        }

        // PUT: api/CampaignDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampaignDocument(int id, CampaignDocument campaignDocument)
        {
            if (id != campaignDocument.Id)
            {
                return BadRequest();
            }

            _context.Entry(campaignDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignDocumentExists(id))
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

        // POST: api/CampaignDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CampaignDocument>> PostCampaignDocument(CampaignDocument campaignDocument)
        {
          if (_context.CampaignDocument == null)
          {
              return Problem("Entity set 'ApiDbContext.CampaignDocument'  is null.");
          }
            _context.CampaignDocument.Add(campaignDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampaignDocument", new { id = campaignDocument.Id }, campaignDocument);
        }

        // DELETE: api/CampaignDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampaignDocument(int id)
        {
            if (_context.CampaignDocument == null)
            {
                return NotFound();
            }
            var campaignDocument = await _context.CampaignDocument.FindAsync(id);
            if (campaignDocument == null)
            {
                return NotFound();
            }

            _context.CampaignDocument.Remove(campaignDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampaignDocumentExists(int id)
        {
            return (_context.CampaignDocument?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
