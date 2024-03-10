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
    public class ModesController : ControllerBase
    {
        private readonly Context_DB _context;

        public ModesController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/Modes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeViewModel>>> GetMode()
        {
            return await _context.Modes
                .Select(mode => CreateModeViewModel(mode))
                .ToListAsync();
        }

        // GET: api/Modes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModeViewModel>> GetMode(Guid id)
        {
            var mode = await _context.Modes.FindAsync(id);

            if (mode == null)
            {
                return NotFound();
            }

            return CreateModeViewModel(mode);
        }

        // PUT: api/Modes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMode(Guid id, ModeViewModel modeViewModel)
        {
            if (id != modeViewModel.Id)
            {
                return BadRequest();
            }

            var mode = await _context.Modes.FindAsync(id);
            if (mode == null)
            {
                return NotFound();
            }

            mode.Name = modeViewModel.Name;

            _context.Entry(mode).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModeExists(id))
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

        // POST: api/Modes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mode>> PostMode(ModeViewModel modeViewModel)
        {
            var mode = new Mode() { Name = modeViewModel.Name };

            _context.Modes.Add(mode);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMode", new { id = mode.Id }, mode);
        }

        // DELETE: api/Modes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMode(Guid id)
        {
            var mode = await _context.Modes.FindAsync(id);
            if (mode == null)
            {
                return NotFound();
            }

            _context.Modes.Remove(mode);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeExists(Guid id)
        {
            return _context.Modes.Any(e => e.Id == id);
        }

        private static ModeViewModel CreateModeViewModel(Mode mode)
        {
            return new ModeViewModel()
            {
                Id = mode.Id,
                Name = mode.Name
            };
        }
    }
}
