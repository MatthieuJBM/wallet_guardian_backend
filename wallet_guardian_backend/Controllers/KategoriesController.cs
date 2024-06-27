using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using wallet_guardian_backend.Data;

namespace wallet_guardian_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriesController : ControllerBase
    {
        private readonly WalletGuardianDbContext _context;

        public KategoriesController(WalletGuardianDbContext context)
        {
            _context = context;
        }

        // GET: api/Kategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategory>>> GetKategories()
        {
            return await _context.Kategories.ToListAsync();
        }

        // GET: api/Kategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategory>> GetKategory(int id)
        {
            var kategory = await _context.Kategories.FindAsync(id);

            if (kategory == null)
            {
                return NotFound();
            }

            return kategory;
        }

        // PUT: api/Kategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategory(int id, Kategory kategory)
        {
            if (id != kategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoryExists(id))
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

        // POST: api/Kategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Kategory>> PostKategory(Kategory kategory)
        {
            _context.Kategories.Add(kategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategory", new { id = kategory.Id }, kategory);
        }

        // DELETE: api/Kategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategory(int id)
        {
            var kategory = await _context.Kategories.FindAsync(id);
            if (kategory == null)
            {
                return NotFound();
            }

            _context.Kategories.Remove(kategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategoryExists(int id)
        {
            return _context.Kategories.Any(e => e.Id == id);
        }
    }
}
