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
    public class UnitFirstsController : ControllerBase
    {
        private readonly Context_DB _context;

        public UnitFirstsController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/UnitFirsts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitFirstViewModel>>> GetUnitFirst()
        {
            return await _context.UnitFirst
                .Select(i => CreateModeViewUnitFirst(i))
                .ToListAsync();
        }

        // GET: api/UnitFirsts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitFirst>> GetUnitFirst(Guid id)
        {
            var unitFirst = await _context.UnitFirst.FindAsync(id);

            if (unitFirst == null)
            {
                return NotFound();
            }

            return unitFirst;
        }

        // PUT: api/UnitFirsts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitFirst(Guid id, UnitFirstViewModel unitFirstViewModel)
        {
            if (id != unitFirstViewModel.Id)
            {
                return BadRequest();
            }


            var unitFirst = await _context.UnitFirst.FindAsync(id);
            if (unitFirst == null)
            {
                return NotFound();
            }

            unitFirst.Name = unitFirstViewModel.Name;

            _context.Entry(unitFirst).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitFirstExists(id))
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

        // POST: api/UnitFirsts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitFirst>> PostUnitFirst(UnitFirstViewModel unitFirstViewModel)
        {
            var incoterm = new UnitFirst() { Name = unitFirstViewModel.Name };

            _context.UnitFirst.Add(incoterm);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitFirst", new { id = incoterm.Id }, incoterm);
        }

        // DELETE: api/UnitFirsts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitFirst(Guid id)
        {
            var unitFirst = await _context.UnitFirst.FindAsync(id);
            if (unitFirst == null)
            {
                return NotFound();
            }

            _context.UnitFirst.Remove(unitFirst);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitFirstExists(Guid id)
        {
            return _context.UnitFirst.Any(e => e.Id == id);
        }

        private static UnitFirstViewModel CreateModeViewUnitFirst(UnitFirst unitFirst)
        {
            return new UnitFirstViewModel()
            {
                Id = unitFirst.Id,
                Name = unitFirst.Name
            };
        }
    }
}
