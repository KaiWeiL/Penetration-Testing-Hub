using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Penetration_Testing_Hub.Data;
using Penetration_Testing_Hub.Models;

namespace Penetration_Testing_Hub.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class PTHThreadsAPIController : ControllerBase
    {
        private readonly PTHDbContext _context;

        public PTHThreadsAPIController(PTHDbContext context)
        {
            _context = context;
        }

        // GET: api/PTHThreadsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PTHThread>>> GetPTHThreads()
        {
            return await _context.PTHThreads.ToListAsync();
        }

        // GET: api/PTHThreadsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PTHThread>> GetPTHThread(int id)
        {
            var pTHThread = await _context.PTHThreads.FindAsync(id);

            if (pTHThread == null)
            {
                return NotFound();
            }

            return pTHThread;
        }

        // PUT: api/PTHThreadsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPTHThread(int id, PTHThread pTHThread)
        {
            if (id != pTHThread.Id)
            {
                return BadRequest();
            }

            _context.Entry(pTHThread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PTHThreadExists(id))
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

        // POST: api/PTHThreadsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PTHThread>> PostPTHThread(PTHThread pTHThread)
        {
            _context.PTHThreads.Add(pTHThread);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPTHThread), new { id = pTHThread.Id }, pTHThread);
        }

        // DELETE: api/PTHThreadsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePTHThread(int id)
        {
            var pTHThread = await _context.PTHThreads.FindAsync(id);
            if (pTHThread == null)
            {
                return NotFound();
            }

            _context.PTHThreads.Remove(pTHThread);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PTHThreadExists(int id)
        {
            return _context.PTHThreads.Any(e => e.Id == id);
        }
    }
}
