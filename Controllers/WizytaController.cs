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
    public class WizytaController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public WizytaController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Wizyta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WizytaForView>>> GetWizyta()
        {
            if (_context.Wizyta == null)
            {
                return NotFound();
            }
            return (await _context.Wizyta
                .Include(wizyta => wizyta.Pacjent)
                .Include(wizyta => wizyta.Pracownik)
                .Include(wizyta => wizyta.Pokoj)
                .ToListAsync())
                .Select(wizyta => ConvertB.ConvertWizytaToWizytaForView(wizyta))
                .ToList();
        }

        // GET: api/Wizyta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WizytaForView>> GetWizyta(int id)
        {
            if (_context.Wizyta == null)
            {
                return NotFound();
            }
            var wizyta = await _context.Wizyta
                .Include(wizyta => wizyta.Pacjent)
                .Include(wizyta => wizyta.Pracownik)
                .Include(wizyta => wizyta.Pokoj)
                .FirstAsync(wizyta => wizyta.Id == id);

            if (wizyta == null)
            {
                return NotFound();
            }

            return Ok(ConvertB.ConvertWizytaToWizytaForView(wizyta));
        }

        // PUT: api/Wizyta/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWizyta(int id, WizytaForView wizyta)
        {
            if (id != wizyta.Id)
            {
                return BadRequest();
            }

            _context.Entry(wizyta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WizytaExists(id))
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

        // POST: api/Wizyta
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WizytaForView>> PostWizyta(WizytaForView wizyta)
        {
            if (_context.Wizyta == null)
            {
                return Problem("Entity set 'PsychoMedikAPIContext.Wizyta'  is null.");
            }
            try
            {
                await WizytaB.WalidujIWypelnijWizyte(wizyta, _context);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            var wizytaToAdd = new Wizyta().CopyProperties(wizyta);
            _context.Wizyta.Add(wizytaToAdd);
            await _context.SaveChangesAsync();

            return Ok(wizyta);
        }

        // DELETE: api/Wizyta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWizyta(int id)
        {
            if (_context.Wizyta == null)
            {
                return NotFound();
            }
            var wizyta = await _context.Wizyta.FindAsync(id);
            if (wizyta == null)
            {
                return NotFound();
            }

            _context.Wizyta.Remove(wizyta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WizytaExists(int id)
        {
            return (_context.Wizyta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
