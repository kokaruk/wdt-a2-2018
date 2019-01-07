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
    public class StockRequestsController : ControllerBase
    {
        private readonly WdtA2ApiProductsContext _context;

        public StockRequestsController(WdtA2ApiProductsContext context)
        {
            _context = context;
        }

        // GET: api/StockRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StockRequest>>> GetStockRequest()
        {
            return await _context.StockRequest.ToListAsync();
        }

        // GET: api/StockRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StockRequest>> GetStockRequest(long id)
        {
            var stockRequest = await _context.StockRequest.FindAsync(id);

            if (stockRequest == null)
            {
                return NotFound();
            }

            return stockRequest;
        }

        // PUT: api/StockRequests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStockRequest(long id, StockRequest stockRequest)
        {
            if (id != stockRequest.StockRequestId)
            {
                return BadRequest();
            }

            _context.Entry(stockRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockRequestExists(id))
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

        // POST: api/StockRequests
        [HttpPost]
        public async Task<ActionResult<StockRequest>> PostStockRequest(StockRequest stockRequest)
        {
            _context.StockRequest.Add(stockRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStockRequest", new { id = stockRequest.StockRequestId }, stockRequest);
        }

        // DELETE: api/StockRequests/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StockRequest>> DeleteStockRequest(long id)
        {
            var stockRequest = await _context.StockRequest.FindAsync(id);
            if (stockRequest == null)
            {
                return NotFound();
            }

            _context.StockRequest.Remove(stockRequest);
            await _context.SaveChangesAsync();

            return stockRequest;
        }

        private bool StockRequestExists(long id)
        {
            return _context.StockRequest.Any(e => e.StockRequestId == id);
        }
    }
}
