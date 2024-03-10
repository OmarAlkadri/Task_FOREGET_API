using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_FOREGET.Models;
using Task_FOREGET.ViewModels;

namespace Task_FOREGET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovementTypesController : ControllerBase
    {
        private readonly Context_DB _context;

        public MovementTypesController(Context_DB context)
        {
            _context = context;
        }

        // GET: api/Modes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovementTypeViewModel>>> GetMode()
        {
            return await _context.MovementTypes
                .Select(movementType => CreateMovementTypeViewModel(movementType))
                .ToListAsync();
        }

        // GET: api/Modes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovementTypeViewModel>> GetMode(Guid id)
        {
            var movementType = await _context.MovementTypes.FindAsync(id);

            if (movementType == null)
            {
                return NotFound();
            }

            return CreateMovementTypeViewModel(movementType);
        }

        // PUT: api/Modes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMode(Guid id, MovementTypeViewModel MovementTypeViewModel)
        {
            if (id != MovementTypeViewModel.Id)
            {
                return BadRequest();
            }

            var movementType = await _context.MovementTypes.FindAsync(id);
            if (movementType == null)
            {
                return NotFound();
            }

            movementType.Name = MovementTypeViewModel.Name;

            _context.Entry(movementType).State = EntityState.Modified;

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
        public async Task<ActionResult<Mode>> PostMode(MovementTypeViewModel movementTypeViewModel)
        {
            var movementType = new MovementType() { Name = movementTypeViewModel.Name };

            _context.MovementTypes.Add(movementType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMode", new { id = movementType.Id }, movementType);
        }

        // DELETE: api/Modes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMode(Guid id)
        {
            var movementTypeViewModel = await _context.MovementTypes.FindAsync(id);
            if (movementTypeViewModel == null)
            {
                return NotFound();
            }

            _context.MovementTypes.Remove(movementTypeViewModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModeExists(Guid id)
        {
            return _context.Modes.Any(e => e.Id == id);
        }

        private static MovementTypeViewModel CreateMovementTypeViewModel(MovementType movementType)
        {
            return new MovementTypeViewModel()
            {
                Id = movementType.Id,
                Name = movementType.Name
            };
        }
    }
}
