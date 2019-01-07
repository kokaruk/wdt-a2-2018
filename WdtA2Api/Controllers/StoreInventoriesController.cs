using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WdtA2Api.Data;
using WdtA2Api.Models;

namespace WdtA2Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreInventoriesController : ControllerBase
    {
        private readonly WdtA2ApiProductsContext _context;

        public StoreInventoriesController(WdtA2ApiProductsContext context)
        {
            _context = context;
        }

        // GET: api/StoreInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreInventory>>> GetStoreInventory()
        {
            var storeInventories = _context.StoreInventory
                .Include(s => s.Store)
                .Include(s => s.Product).AsNoTracking();
            return await storeInventories.ToListAsync();
        }

        // GET: api/StoreInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StoreInventory>> GetStoreInventory(long id)
        {
            var storeInventory = await _context.StoreInventory.FindAsync(id);

            if (storeInventory == null)
            {
                return NotFound();
            }

            return storeInventory;
        }

        // PUT: api/StoreInventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStoreInventory(long id, StoreInventory storeInventory)
        {
            if (id != storeInventory.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(storeInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreInventoryExists(id))
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

        // POST: api/StoreInventories
        [HttpPost]
        public async Task<ActionResult<StoreInventory>> PostStoreInventory(StoreInventory storeInventory)
        {
            _context.StoreInventory.Add(storeInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StoreInventoryExists(storeInventory.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStoreInventory", new { id = storeInventory.ProductId }, storeInventory);
        }

        // DELETE: api/StoreInventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StoreInventory>> DeleteStoreInventory(long id)
        {
            var storeInventory = await _context.StoreInventory.FindAsync(id);
            if (storeInventory == null)
            {
                return NotFound();
            }

            _context.StoreInventory.Remove(storeInventory);
            await _context.SaveChangesAsync();

            return storeInventory;
        }

        private bool StoreInventoryExists(long id)
        {
            return _context.StoreInventory.Any(e => e.ProductId == id);
        }
    }
}
