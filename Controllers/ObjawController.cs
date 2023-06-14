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
    public class ObjawController : ControllerBase
    {
        private readonly PsychoMedikAPIContext _context;

        public ObjawController(PsychoMedikAPIContext context)
        {
            _context = context;
        }

        // GET: api/Objaw
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objaw>>> GetObjaw()
        {
          if (_context.Objaw == null)
          {
              return NotFound();
          }
            return await _context.Objaw.ToListAsync();
        }

        // GET: api/Objaw/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objaw>> GetObjaw(int id)
        {
          if (_context.Objaw == null)
          {
              return NotFound();
          }
            var objaw = await _context.Objaw.FindAsync(id);

            if (objaw == null)
            {
                return NotFound();
            }

            return objaw;
        }

        // PUT: api/Objaw/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjaw(int id, Objaw objaw)
        {
            if (id != objaw.Id)
            {
                return BadRequest();
            }

            _context.Entry(objaw).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjawExists(id))
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

        // POST: api/Objaw
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Objaw>> PostObjaw(Objaw objaw)
        {
          if (_context.Objaw == null)
          {
              return Problem("Entity set 'PsychoMedikAPIContext.Objaw'  is null.");
          }
            _context.Objaw.Add(objaw);
            await _context.SaveChangesAsync();

            return Ok(objaw);
        }

        // DELETE: api/Objaw/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObjaw(int id)
        {
            if (_context.Objaw == null)
            {
                return NotFound();
            }
            var objaw = await _context.Objaw.FindAsync(id);
            if (objaw == null)
            {
                return NotFound();
            }

            _context.Objaw.Remove(objaw);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObjawExists(int id)
        {
            return (_context.Objaw?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
