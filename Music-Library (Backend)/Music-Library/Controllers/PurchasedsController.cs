using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music_Library.Data;
using Music_Library.Entities;

namespace Music_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasedsController : ControllerBase
    {
        private readonly DataContext _context;

        public PurchasedsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Purchaseds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchased>>> GetPurchased()
        {
          if (_context.Purchased == null)
          {
              return NotFound();
          }
            return await _context.Purchased.ToListAsync();
        }

        // GET: api/Purchaseds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Purchased>> GetPurchased(int id)
        {
          if (_context.Purchased == null)
          {
              return NotFound();
          }
            var purchased = await _context.Purchased.FindAsync(id);

            if (purchased == null)
            {
                return NotFound();
            }

            return purchased;
        }

        [HttpGet("getuid/{uidinp}")]
        public async Task<ActionResult<IEnumerable<Purchased>>> GetPurchaseduid(int uidinp)
        {
            if (_context.Purchased == null)
            {
                return NotFound();
            }
            var Purchased = await _context.Purchased.Where(x => x.UID == uidinp).ToListAsync();

            if (Purchased == null)
            {
                return NotFound();
            }
            return Purchased;
        }

        [HttpGet("getfav/{uidinp}")]
        public async Task<ActionResult<IEnumerable<Purchased>>> GetPurchasedFav(int uidinp)
        {
            if (_context.Purchased == null)
            {
                return NotFound();
            }
            var Purchased = await _context.Purchased.Where(x => x.Favorite == true&& x.UID==uidinp).ToListAsync();

            if (Purchased == null)
            {
                return NotFound();
            }
            return Purchased;
        }

        // PUT: api/Purchaseds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPurchased(int id, Purchased purchased)
        {
            if (id != purchased.ID)
            {
                return BadRequest();
            }
            _context.Entry(purchased).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchasedExists(id))
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

        // POST: api/Purchaseds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Purchased>> PostPurchased(Purchased purchased)
        {
          if (_context.Purchased == null)
          {
              return Problem("Entity set 'DataContext.Purchased' is null.");
          }
            purchased.Purchase_date = DateTime.Now;
            purchased.Favorite = false;
            _context.Purchased.Add(purchased);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPurchased", new { id = purchased.ID }, purchased);
        }

        

        // DELETE: api/Purchaseds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchased(int id)
        {
            if (_context.Purchased == null)
            {
                return NotFound();
            }
            var purchased = await _context.Purchased.FindAsync(id);
            if (purchased == null)
            {
                return NotFound();
            }

            _context.Purchased.Remove(purchased);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PurchasedExists(int id)
        {
            return (_context.Purchased?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
