using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoMedikAPI.BusinessLogic;
using PsychoMedikAPI.Data;
using PsychoMedikAPI.Models;
using PsychoMedikAPI.ViewModels;
using PsychoMedikApp.Helpers;

namespace PsychoMedikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacjentController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public PacjentController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pacjent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacjentForView>>> GetPacjent()
        {
            if (_context.Pacjent == null)
            {
                return NotFound();
            }
            return (await _context
                .Pacjent
                .Include(pacjent => pacjent.Pracownik)
                .ToListAsync())
                .Select(pacjent => ConvertB.ConvertPacjentToPacjentForView(pacjent))
                .ToList();
        }

        // GET: api/Pacjent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PacjentForView>> GetPacjent(int id)
        {
            if (_context.Pacjent == null)
            {
                return NotFound();
            }
            var pacjent = await _context.Pacjent
                .Include(pacjent => pacjent.Pracownik)
                .FirstAsync(pacjent => pacjent.Id == id);

            if (pacjent == null)
            {
                return NotFound();
            }

            return ConvertB.ConvertPacjentToPacjentForView(pacjent);
        }

        // PUT: api/Pacjent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPacjent(int id, PacjentForView pacjent)
        {
            if (id != pacjent.Id)
            {
                return BadRequest();
            }

            _context.Entry(pacjent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacjentExists(id))
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

        // POST: api/Pacjent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PacjentForView>> PostPacjent(PacjentForView pacjent)
        {
            if (_context.Pacjent == null)
            {
                return Problem("Entity set 'PsychoMedikAPIContext.Pacjent'  is null.");
            }
            var pacjentToAdd = new Pacjent().CopyProperties(pacjent);
            _context.Pacjent.Add(pacjentToAdd);
            await _context.SaveChangesAsync();

            return Ok(pacjent);
        }

        // DELETE: api/Pacjent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePacjent(int id)
        {
            if (_context.Pacjent == null)
            {
                return NotFound();
            }
            var pacjent = await _context.Pacjent.FindAsync(id);
            if (pacjent == null)
            {
                return NotFound();
            }

            _context.Pacjent.Remove(pacjent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PacjentExists(int id)
        {
            return (_context.Pacjent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
