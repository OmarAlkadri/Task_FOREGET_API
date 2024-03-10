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
    public class ShipmentsController : ControllerBase
    {
        private readonly Context_DB _context;

        public ShipmentsController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/Shipments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentViewModel>>> GetShipment()
        {
            var shipmentViewModels = await _context.Shipments
                .Include(f => f.Mode)
                .Include(f => f.MovementType)
                .Include(f => f.Incoterm)
                .Include(f => f.PackageType)
                .Include(f => f.UnitFirst)
                .Include(f => f.SecondUnit)
                .Include(f => f.Currency)
                .Select(shipment => CreatShipmentViewModel(shipment))
                .ToListAsync();

            return shipmentViewModels;
        }

        // GET: api/Shipments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentViewModel>> GetShipments(Guid id)
        {
            var shipment = await _context.Shipments
                .Include(f => f.Mode)
                .Include(f => f.MovementType)
                .Include(f => f.Incoterm)
                .FirstOrDefaultAsync(shipment => shipment.Id == id);

            if (shipment == null)
            {
                return NotFound();
            }

            return CreatShipmentViewModel(shipment);
        }

        // PUT: api/Shipments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipments(Guid id, ShipmentViewModel shipmentViewModel)
        {
            if (id != shipmentViewModel.Id)
            {
                return BadRequest();
            }

            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }

            shipment.ModeId = shipmentViewModel.ModeId;
            shipment.MovementTypeId = shipmentViewModel.MovementTypeId;
            shipment.IncotermId = shipmentViewModel.IncotermId;
            shipment.country = shipmentViewModel.Country;
            shipment.citiy = shipmentViewModel.City;
            shipment.PackageTypeId = shipmentViewModel.PackageTypeId;
            shipment.UnitFirstId = shipmentViewModel.UnitFirstId;
            shipment.SecondUnitId = shipmentViewModel.SecondUnitId;
            shipment.CurrencyId = shipmentViewModel.CurrencyId;

            // Check maybe I can delete it.
            _context.Entry(shipment).State = EntityState.Modified;

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
        public async Task<ActionResult<ShipmentViewModel>> PostShipments(ShipmentViewModel shipmentViewModel)
        {
            var shipment = new Shipment()
            {
                ModeId = shipmentViewModel.ModeId,
                MovementTypeId = shipmentViewModel.MovementTypeId,
                PackageTypeId = shipmentViewModel.PackageTypeId,
                IncotermId = shipmentViewModel.IncotermId,
                SecondUnitId = shipmentViewModel.SecondUnitId,
                country = shipmentViewModel.Country,
                citiy = shipmentViewModel.City,
                UnitFirstId = shipmentViewModel.UnitFirstId,
                CurrencyId = shipmentViewModel.CurrencyId
            };

            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipments", new { id = shipment.Id }, shipment);
        }

        // DELETE: api/Shipments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipments(Guid id)
        {
            var shipments = await _context.Shipments.FindAsync(id);
            if (shipments == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(shipments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentsExists(Guid id)
        {
            return _context.Shipments.Any(e => e.Id == id);
        }

        private static ShipmentViewModel CreatShipmentViewModel(Shipment shipment)
        {
            return new ShipmentViewModel()
            {
                Id = shipment.Id,
                ModeId = shipment.ModeId,
                ModeName = shipment.Mode.Name,
                MovementTypeId = shipment.MovementTypeId,
                MovementTypeName = shipment.MovementType.Name,
                IncotermId = shipment.IncotermId,
                IncotermName = shipment.Incoterm.Name,
                PackageTypeName = shipment.PackageType.Name,
                UnitFirstName = shipment.UnitFirst.Name,
                SecondUnitName = shipment.SecondUnit.Name,
                CurrencyName = shipment.Currency.Name,
                Country = shipment.country,
                City = shipment.citiy,
                PackageTypeId = shipment.PackageTypeId,
                UnitFirstId = shipment.UnitFirstId,
                SecondUnitId = shipment.SecondUnitId,
                CurrencyId = shipment.CurrencyId
            };
        }
    }
}
