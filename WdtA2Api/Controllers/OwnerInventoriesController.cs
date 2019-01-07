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
    public class OwnerInventoriesController : ControllerBase
    {
        private readonly WdtA2ApiProductsContext _context;

        public OwnerInventoriesController(WdtA2ApiProductsContext context)
        {
            _context = context;
        }

        // GET: api/OwnerInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerInventory>>> GetOwnerInventory()
        {
            return await _context.OwnerInventory.ToListAsync();
        }

        // GET: api/OwnerInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerInventory>> GetOwnerInventory(long id)
        {
            var ownerInventory = await _context.OwnerInventory.FindAsync(id);

            if (ownerInventory == null)
            {
                return NotFound();
            }

            return ownerInventory;
        }

        // PUT: api/OwnerInventories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwnerInventory(long id, OwnerInventory ownerInventory)
        {
            if (id != ownerInventory.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(ownerInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OwnerInventoryExists(id))
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

        // POST: api/OwnerInventories
        [HttpPost]
        public async Task<ActionResult<OwnerInventory>> PostOwnerInventory(OwnerInventory ownerInventory)
        {
            _context.OwnerInventory.Add(ownerInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OwnerInventoryExists(ownerInventory.ProductId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetOwnerInventory", new { id = ownerInventory.ProductId }, ownerInventory);
        }

        // DELETE: api/OwnerInventories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OwnerInventory>> DeleteOwnerInventory(long id)
        {
            var ownerInventory = await _context.OwnerInventory.FindAsync(id);
            if (ownerInventory == null)
            {
                return NotFound();
            }

            _context.OwnerInventory.Remove(ownerInventory);
            await _context.SaveChangesAsync();

            return ownerInventory;
        }

        private bool OwnerInventoryExists(long id)
        {
            return _context.OwnerInventory.Any(e => e.ProductId == id);
        }
    }
}
