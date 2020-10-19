using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DClientController : ControllerBase
    {
        private readonly DonationDBContext _context;

        public DClientController(DonationDBContext context)
        {
            _context = context;
        }

        // GET: api/DClient
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DClient>>> GetDClients()
        {
            return await _context.DClients.ToListAsync();
        }

        // GET: api/DClient/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DClient>> GetDClient(int id)
        {
            var dCandidate = await _context.DClients.FindAsync(id);

            if (dCandidate == null)
            {
                return NotFound();
            }

            return dCandidate;
        }

        // PUT: api/DClient/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDCandidate(int id, DClient dClient)
        {
            /*
            if (id != dCandidate.Id)
            {
                return BadRequest();
            }
            */
            dClient.Id = id;

            _context.Entry(dClient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DClientsExists(id))
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

        // POST: api/DCandidate
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DClient>> PostDCandidate(DClient dClient)
        {
            _context.DClients.Add(dClient);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDClient", new { id = dClient.Id }, dClient);
        }

        // DELETE: api/DClient/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DClient>> DeleteDCandidate(int id)
        {
            var dClient = await _context.DClients.FindAsync(id);
            if (dClient == null)
            {
                return NotFound();
            }

            _context.DClients.Remove(dClient);
            await _context.SaveChangesAsync();

            return dClient;
        }

        private bool DClientsExists(int id)
        {
            return _context.DClients.Any(e => e.Id == id);
        }
    }
}
