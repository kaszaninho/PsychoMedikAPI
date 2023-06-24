using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoMedikAPI.Data;
using PsychoMedikAPI.Models;

namespace PsychoMedikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChorobaController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public ChorobaController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Choroba
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Choroba>>> GetChoroba()
        {
            if (_context.Choroba == null)
            {
                return NotFound();
            }
            return await _context.Choroba.ToListAsync();
        }

        // GET: api/Choroba/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Choroba>> GetChoroba(int id)
        {
            if (_context.Choroba == null)
            {
                return NotFound();
            }
            var choroba = await _context.Choroba.FindAsync(id);

            if (choroba == null)
            {
                return NotFound();
            }

            return choroba;
        }

        // PUT: api/Choroba/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChoroba(int id, Choroba choroba)
        {
            if (id != choroba.Id)
            {
                return BadRequest();
            }

            _context.Entry(choroba).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChorobaExists(id))
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

        // POST: api/Choroba
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Choroba>> PostChoroba(Choroba choroba)
        {
            if (_context.Choroba == null)
            {
                return Problem("Entity set 'PsychoMedikAPIContext.Choroba'  is null.");
            }
            _context.Choroba.Add(choroba);
            await _context.SaveChangesAsync();

            return Ok(choroba);
        }

        // DELETE: api/Choroba/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChoroba(int id)
        {
            if (_context.Choroba == null)
            {
                return NotFound();
            }
            var choroba = await _context.Choroba.FindAsync(id);
            if (choroba == null)
            {
                return NotFound();
            }

            _context.Choroba.Remove(choroba);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChorobaExists(int id)
        {
            return (_context.Choroba?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
