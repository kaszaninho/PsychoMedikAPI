using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychoMedikAPI.Data;
using PsychoMedikAPI.Models;

namespace PsychoMedikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StanowiskoController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public StanowiskoController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Stanowisko
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stanowisko>>> GetStanowisko()
        {
          if (_context.Stanowisko == null)
          {
              return NotFound();
          }
            return await _context.Stanowisko.ToListAsync();
        }

        // GET: api/Stanowisko/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stanowisko>> GetStanowisko(int id)
        {
          if (_context.Stanowisko == null)
          {
              return NotFound();
          }
            var stanowisko = await _context.Stanowisko.FindAsync(id);

            if (stanowisko == null)
            {
                return NotFound();
            }

            return stanowisko;
        }

        // PUT: api/Stanowisko/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStanowisko(int id, Stanowisko stanowisko)
        {
            if (id != stanowisko.Id)
            {
                return BadRequest();
            }

            _context.Entry(stanowisko).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StanowiskoExists(id))
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

        // POST: api/Stanowisko
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stanowisko>> PostStanowisko(Stanowisko stanowisko)
        {
          if (_context.Stanowisko == null)
          {
              return Problem("Entity set 'PsychoMedikAPIContext.Stanowisko'  is null.");
          }
            _context.Stanowisko.Add(stanowisko);
            await _context.SaveChangesAsync();

            return Ok(stanowisko);
        }

        // DELETE: api/Stanowisko/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStanowisko(int id)
        {
            if (_context.Stanowisko == null)
            {
                return NotFound();
            }
            var stanowisko = await _context.Stanowisko.FindAsync(id);
            if (stanowisko == null)
            {
                return NotFound();
            }

            _context.Stanowisko.Remove(stanowisko);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StanowiskoExists(int id)
        {
            return (_context.Stanowisko?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
