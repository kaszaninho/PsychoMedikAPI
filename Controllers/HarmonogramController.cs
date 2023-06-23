using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
    public class HarmonogramController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public HarmonogramController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Harmonogram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HarmonogramForView>>> GetHarmonogram()
        {
          if (_context.Harmonogram == null)
          {
              return NotFound();
          }
            return (await _context
                .Harmonogram
                .Include(item => item.Pracownik)
                .ToListAsync())
                .Select(harmonogram => ConvertB.ConvertHarmonogramToHarmonogramForView(harmonogram))
                .ToList();
        }

        // GET: api/Harmonogram/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HarmonogramForView>> GetHarmonogram(int id)
        {
          if (_context.Harmonogram == null)
          {
              return NotFound();
          }
            var harmonogram = await _context.Harmonogram
                .Include(harmonogram => harmonogram.Pracownik)
                .FirstAsync(harmonogram => harmonogram.Id == id);

            if (harmonogram == null)
            {
                return NotFound();
            }

            return ConvertB.ConvertHarmonogramToHarmonogramForView(harmonogram);
        }

        // PUT: api/Harmonogram/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHarmonogram(int id, HarmonogramForView harmonogram)
        {
            if (id != harmonogram.Id)
            {
                return BadRequest();
            }

            _context.Entry(harmonogram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HarmonogramExists(id))
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

        // POST: api/Harmonogram
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HarmonogramForView>> PostHarmonogram(HarmonogramForView harmonogram)
        {
          if (_context.Harmonogram == null)
          {
              return Problem("Entity set 'PsychoMedikAPIContext.Harmonogram'  is null.");
          }
            var harmonogramToAdd = new Harmonogram().CopyProperties(harmonogram);
            _context.Harmonogram.Add(harmonogramToAdd);
            await _context.SaveChangesAsync();

            return Ok(harmonogram);
        }

        // DELETE: api/Harmonogram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHarmonogram(int id)
        {
            if (_context.Harmonogram == null)
            {
                return NotFound();
            }
            var harmonogram = await _context.Harmonogram.FindAsync(id);
            if (harmonogram == null)
            {
                return NotFound();
            }

            _context.Harmonogram.Remove(harmonogram);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HarmonogramExists(int id)
        {
            return (_context.Harmonogram?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
