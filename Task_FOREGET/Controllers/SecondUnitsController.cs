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
    public class SecondUnitsController : ControllerBase
    {
        private readonly Context_DB _context;

        public SecondUnitsController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/SecondUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecondUnitViewModel>>> GetSecondUnit()
        {
            return await _context.SecondUnit
                .Select(i => CreateSecondUnitViewModel(i))
                .ToListAsync();
        }

        // GET: api/SecondUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecondUnit>> GetSecondUnit(Guid id)
        {
            var secondUnit = await _context.SecondUnit.FindAsync(id);

            if (secondUnit == null)
            {
                return NotFound();
            }

            return secondUnit;
        }

        // PUT: api/SecondUnits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecondUnit(Guid id, SecondUnitViewModel secondUnitViewModel)
        {
            if (id != secondUnitViewModel.Id)
            {
                return BadRequest();
            }

            var secondUnit = await _context.SecondUnit.FindAsync(id);
            if (secondUnit == null)
            {
                return NotFound();
            }

            secondUnit.Name = secondUnitViewModel.Name;

            _context.Entry(secondUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecondUnitExists(id))
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

        // POST: api/SecondUnits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SecondUnit>> PostSecondUnit(SecondUnitViewModel secondUnitViewModel)
        {
            var secondUnit = new SecondUnit() { Name = secondUnitViewModel.Name };

            _context.SecondUnit.Add(secondUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecondUnit", new { id = secondUnit.Id }, secondUnit);
        }

        // DELETE: api/SecondUnits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecondUnit(Guid id)
        {
            var secondUnit = await _context.SecondUnit.FindAsync(id);
            if (secondUnit == null)
            {
                return NotFound();
            }

            _context.SecondUnit.Remove(secondUnit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecondUnitExists(Guid id)
        {
            return _context.SecondUnit.Any(e => e.Id == id);
        }

        private static SecondUnitViewModel CreateSecondUnitViewModel(SecondUnit secondUnit)
        {
            return new SecondUnitViewModel()
            {
                Id = secondUnit.Id,
                Name = secondUnit.Name
            };
        }
    }
}
