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
    public class PackageTypesController : ControllerBase
    {
        private readonly Context_DB _context;

        public PackageTypesController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/PackageTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageTypeViewModel>>> GetPackageType()
        {
            return await _context.PackageType
                .Select(i => CreatePackageTypeViewModel(i))
                .ToListAsync();
        }

        // GET: api/PackageTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageType>> GetPackageType(Guid id)
        {
            var packageType = await _context.PackageType.FindAsync(id);

            if (packageType == null)
            {
                return NotFound();
            }

            return packageType;
        }

        // PUT: api/PackageTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackageType(Guid id, PackageTypeViewModel packageTypeViewModel)
        {
            if (id != packageTypeViewModel.Id)
            {
                return BadRequest();
            }

            var packageType = await _context.PackageType.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }

            packageType.Name = packageTypeViewModel.Name;

            _context.Entry(packageType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageTypeExists(id))
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

        // POST: api/PackageTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageType>> PostPackageType(PackageTypeViewModel packageTypeViewModel)
        {

            var packageType = new PackageType() { Name = packageTypeViewModel.Name };

            _context.PackageType.Add(packageType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageType", new { id = packageType.Id }, packageType);
        }

        // DELETE: api/PackageTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageType(Guid id)
        {
            var packageType = await _context.PackageType.FindAsync(id);
            if (packageType == null)
            {
                return NotFound();
            }

            _context.PackageType.Remove(packageType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageTypeExists(Guid id)
        {
            return _context.PackageType.Any(e => e.Id == id);
        }

        private static PackageTypeViewModel CreatePackageTypeViewModel(PackageType packageType)
        {
            return new PackageTypeViewModel()
            {
                Id = packageType.Id,
                Name = packageType.Name
            };
        }
    }
}
