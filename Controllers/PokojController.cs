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
    public class PokojController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public PokojController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Pokoj
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pokoj>>> GetPokoj()
        {
          if (_context.Pokoj == null)
          {
              return NotFound();
          }
            return await _context.Pokoj.ToListAsync();
        }

        // GET: api/Pokoj/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pokoj>> GetPokoj(int id)
        {
          if (_context.Pokoj == null)
          {
              return NotFound();
          }
            var pokoj = await _context.Pokoj.FindAsync(id);

            if (pokoj == null)
            {
                return NotFound();
            }

            return pokoj;
        }

        // PUT: api/Pokoj/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPokoj(int id, Pokoj pokoj)
        {
            if (id != pokoj.Id)
            {
                return BadRequest();
            }

            _context.Entry(pokoj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokojExists(id))
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

        // POST: api/Pokoj
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pokoj>> PostPokoj(Pokoj pokoj)
        {
          if (_context.Pokoj == null)
          {
              return Problem("Entity set 'PsychoMedikAPIContext.Pokoj'  is null.");
          }
            _context.Pokoj.Add(pokoj);
            await _context.SaveChangesAsync();

            return Ok(pokoj);
        }

        // DELETE: api/Pokoj/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePokoj(int id)
        {
            if (_context.Pokoj == null)
            {
                return NotFound();
            }
            var pokoj = await _context.Pokoj.FindAsync(id);
            if (pokoj == null)
            {
                return NotFound();
            }

            _context.Pokoj.Remove(pokoj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PokojExists(int id)
        {
            return (_context.Pokoj?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
