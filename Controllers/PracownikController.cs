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
    public class PracownikController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public PracownikController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pracownik
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PracownikForView>>> GetPracownik()
        {
            if (_context.Pracownik == null)
            {
                return NotFound();
            }
            return (await _context
                .Pracownik
                .Include(pracownik => pracownik.Stanowisko)
                .ToListAsync())
                .Select(pracownik => ConvertB.ConvertPracownikToPracownikForView(pracownik))
                .ToList();
        }

        // GET: api/Pracownik/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PracownikForView>> GetPracownik(int id)
        {
            if (_context.Pracownik == null)
            {
                return NotFound();
            }
            var pracownik = await _context.Pracownik
                .Include(pracownik => pracownik.Stanowisko)
                .FirstAsync(pracownik => pracownik.Id == id);

            if (pracownik == null)
            {
                return NotFound();
            }

            return ConvertB.ConvertPracownikToPracownikForView(pracownik);
        }

        // PUT: api/Pracownik/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPracownik(int id, PracownikForView pracownik)
        {
            if (id != pracownik.Id)
            {
                return BadRequest();
            }

            _context.Entry(pracownik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikExists(id))
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

        // POST: api/Pracownik
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PracownikForView>> PostPracownik(PracownikForView pracownik)
        {
            if (_context.Pracownik == null)
            {
                return Problem("Entity set 'PsychoMedikAPIContext.Pracownik'  is null.");
            }
            var pracownikToAdd = new Pracownik().CopyProperties(pracownik);
            _context.Pracownik.Add(pracownikToAdd);
            await _context.SaveChangesAsync();

            return Ok(pracownik);
        }

        // DELETE: api/Pracownik/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePracownik(int id)
        {
            if (_context.Pracownik == null)
            {
                return NotFound();
            }
            var pracownik = await _context.Pracownik.FindAsync(id);
            if (pracownik == null)
            {
                return NotFound();
            }

            _context.Pracownik.Remove(pracownik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PracownikExists(int id)
        {
            return (_context.Pracownik?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
