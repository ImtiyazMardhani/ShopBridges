using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridgeModelLayer;

namespace ShopBridgeAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryApiControllers : ControllerBase
    {
        private readonly InventoryContext _context;

        public InventoryApiControllers(InventoryContext context)
        {
            _context = context;
        }

        // GET: api/InventoryApiControllers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventory>>> Getinventory()
        {
            return await _context.inventory.ToListAsync();
        }

        // GET: api/InventoryApiControllers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventory>> GetInventory(Guid id)
        {
            var inventory = await _context.inventory.FindAsync(id);

            if (inventory == null)
            {
                return NotFound();
            }

            return inventory;
        }

        // PUT: api/InventoryApiControllers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventory(Guid id, Inventory inventory)
        {
            if (id != inventory.id)
            {
                return BadRequest();
            }

            _context.Entry(inventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(id))
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

        // POST: api/InventoryApiControllers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inventory>> PostInventory(Inventory inventory)
        {
            _context.inventory.Add(inventory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInventory", new { id = inventory.id }, inventory);
        }

        // DELETE: api/InventoryApiControllers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            var inventory = await _context.inventory.FindAsync(id);
            if (inventory == null)
            {
                return NotFound();
            }

            _context.inventory.Remove(inventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventoryExists(Guid id)
        {
            return _context.inventory.Any(e => e.id == id);
        }
    }
}
