using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_FOREGET;
using Task_FOREGET.Models;

namespace Task_FOREGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly Context_DB _context;

        public ShipmentsController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipments>>> GetShipment()
        {
            return await _context.Shipment.ToListAsync();
        }

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipments>> GetShipments(Guid id)
        {
            var shipments = await _context.Shipment.FindAsync(id);

            if (shipments == null)
            {
                return NotFound();
            }

            return shipments;
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipments(Guid id, Shipments shipments)
        {
            if (id != shipments.Id)
            {
                return BadRequest();
            }

            _context.Entry(shipments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentsExists(id))
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

        // POST: api/Shipments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Shipments>> PostShipments(Shipments shipments)
        {
            _context.Shipment.Add(shipments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipments", new { id = shipments.Id }, shipments);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipments(Guid id)
        {
            var shipments = await _context.Shipment.FindAsync(id);
            if (shipments == null)
            {
                return NotFound();
            }

            _context.Shipment.Remove(shipments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentsExists(Guid id)
        {
            return _context.Shipment.Any(e => e.Id == id);
        }
    }
}
