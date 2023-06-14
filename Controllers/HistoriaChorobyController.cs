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
    public class HistoriaChorobyController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public HistoriaChorobyController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/HistoriaChoroby
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoriaChorobyForView>>> GetHistoriaChoroby()
        {
            if (_context.HistoriaChoroby == null)
            {
                return NotFound();
            }
            return (await _context.HistoriaChoroby
                .Include(historiaChoroby => historiaChoroby.Pracownik)
                .Include(historiaChoroby => historiaChoroby.Pacjent)
                .Include(historiaChoroby => historiaChoroby.Choroba)
                .ToListAsync())
                .Select(historiaChoroby => ConvertB.ConvertHistoriaChorobyToHistoriaChorobyForView(historiaChoroby))
                .ToList();
        }

        // GET: api/HistoriaChoroby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoriaChorobyForView>> GetHistoriaChoroby(int id)
        {
            if (_context.HistoriaChoroby == null)
            {
                return NotFound();
            }
            var historiaChoroby = await _context.HistoriaChoroby.FindAsync(id);

            if (historiaChoroby == null)
            {
                return NotFound();
            }

            return ConvertB.ConvertHistoriaChorobyToHistoriaChorobyForView(historiaChoroby);
        }

        // PUT: api/HistoriaChoroby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistoriaChoroby(int id, HistoriaChorobyForView historiaChoroby)
        {
            if (id != historiaChoroby.Id)
            {
                return BadRequest();
            }
            _context.Entry(historiaChoroby).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistoriaChorobyExists(id))
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

        // POST: api/HistoriaChoroby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistoriaChorobyForView>> PostHistoriaChoroby(HistoriaChorobyForView historiaChoroby)
        {
            if (_context.HistoriaChoroby == null)
            {
                return Problem("Entity set 'PsychoMedikAPIContext.HistoriaChoroby'  is null.");
            }
            try
            {
                await HistoriaChorobyB.WalidujIWypelnijHistorie(historiaChoroby, _context);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
            var historiaChorobyToAdd = new HistoriaChoroby().CopyProperties(historiaChoroby);
            _context.HistoriaChoroby.Add(historiaChorobyToAdd);
            await _context.SaveChangesAsync();

            return Ok(historiaChoroby);
        }

        // DELETE: api/HistoriaChoroby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoriaChoroby(int id)
        {
            if (_context.HistoriaChoroby == null)
            {
                return NotFound();
            }
            var historiaChoroby = await _context.HistoriaChoroby.FindAsync(id);
            if (historiaChoroby == null)
            {
                return NotFound();
            }

            _context.HistoriaChoroby.Remove(historiaChoroby);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistoriaChorobyExists(int id)
        {
            return (_context.HistoriaChoroby?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
