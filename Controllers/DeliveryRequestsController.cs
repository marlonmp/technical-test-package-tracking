using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ccs.Data;
using ccs.Models;

namespace ccs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryRequestsController : ControllerBase
    {
        private readonly CCSContext _context;

        public DeliveryRequestsController(CCSContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryRequest>>> GetDeliveryRequest()
        {
            return await _context.DeliveryRequests.ToListAsync();
        }

        // GET: api/DeliveryRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryRequest>> GetDeliveryRequest(int id)
        {
            var deliveryRequest = await _context.DeliveryRequests.FindAsync(id);

            if (deliveryRequest == null)
            {
                return NotFound();
            }

            return deliveryRequest;
        }

        // PUT: api/DeliveryRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryRequest(int id, DeliveryRequest deliveryRequest)
        {
            if (id != deliveryRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryRequestExists(id))
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

        // POST: api/DeliveryRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeliveryRequest>> PostDeliveryRequest(DeliveryRequest deliveryRequest)
        {
            _context.DeliveryRequests.Add(deliveryRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryRequest", new { id = deliveryRequest.Id }, deliveryRequest);
        }

        // DELETE: api/DeliveryRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryRequest(int id)
        {
            var deliveryRequest = await _context.DeliveryRequests.FindAsync(id);
            if (deliveryRequest == null)
            {
                return NotFound();
            }

            _context.DeliveryRequests.Remove(deliveryRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryRequestExists(int id)
        {
            return _context.DeliveryRequests.Any(e => e.Id == id);
        }
    }
}
