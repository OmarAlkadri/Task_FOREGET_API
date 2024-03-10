using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_FOREGET;
using Task_FOREGET.Models;
using Task_FOREGET.ViewModels;

namespace Task_FOREGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncotermsController : ControllerBase
    {
        private readonly Context_DB _context;

        public IncotermsController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/Incoterms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncotermViewModel>>> GetIncoterms()
        {
            return await _context.Incoterms
                .Select(i => CreateModeViewIncoterm(i))
                .ToListAsync();
        }

        // GET: api/Incoterms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Incoterms>> GetIncoterms(Guid id)
        {
            var incoterms = await _context.Incoterms.FindAsync(id);

            if (incoterms == null)
            {
                return NotFound();
            }

            return incoterms;
        }

        // PUT: api/Incoterms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncoterms(Guid id, IncotermViewModel incotermViewModel)
        {
            if (id != incotermViewModel.Id)
            {
                return BadRequest();
            }

            var incoterm = await _context.Incoterms.FindAsync(id);
            if (incoterm == null)
            {
                return NotFound();
            }

            incoterm.Name = incotermViewModel.Name;

            _context.Entry(incoterm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncotermsExists(id))
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

        // POST: api/Incoterms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Incoterms>> PostIncoterms(IncotermViewModel incotermViewModel)
        {

            var incoterm = new Incoterms() { Name = incotermViewModel.Name };

            _context.Incoterms.Add(incoterm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncoterms", new { id = incoterm.Id }, incoterm);
        }

        // DELETE: api/Incoterms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncoterms(Guid id)
        {
            var incoterms = await _context.Incoterms.FindAsync(id);
            if (incoterms == null)
            {
                return NotFound();
            }

            _context.Incoterms.Remove(incoterms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncotermsExists(Guid id)
        {
            return _context.Incoterms.Any(e => e.Id == id);
        }

        private static IncotermViewModel CreateModeViewIncoterm(Incoterms incoterm)
        {
            return new IncotermViewModel()
            {
                Id = incoterm.Id,
                Name = incoterm.Name
            };
        }
    }
}
