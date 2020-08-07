using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models.EarlyCompletion;
using backend.Interface;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EarlyCompletionsController : ControllerBase
    {
        private readonly EarlyCompletionContext _context;

        public EarlyCompletionsController(EarlyCompletionContext context)
        {
            _context = context;
        }

        // GET: api/EarlyCompletions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EarlyCompletion>>> GetEarlyCompletions()
        {
            return await _context.EarlyCompletions.ToListAsync();
        }

        // GET: api/EarlyCompletions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EarlyCompletion>> GetEarlyCompletion(int id)
        {
            var earlyCompletion = await _context.EarlyCompletions.FindAsync(id);

            if (earlyCompletion == null)
            {
                return NotFound();
            }

            return earlyCompletion;
        }

        // PUT: api/EarlyCompletions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEarlyCompletion(int id, EarlyCompletion earlyCompletion)
        {
            if (id != earlyCompletion.EarlyCompletionId)
            {
                return BadRequest();
            }

            _context.Entry(earlyCompletion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EarlyCompletionExists(id))
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

        // POST: api/EarlyCompletions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EarlyCompletionsPost>> PostEarlyCompletion(EarlyCompletionsPost earlyCompletionsPost)
        {
            var newEarlyCompletions = new EarlyCompletion { EarlyCompletionPhone = earlyCompletionsPost.EarlyCompletionPhone, EarlyCompletionCause = earlyCompletionsPost.EarlyCompletionCause, OtherInformation = earlyCompletionsPost.OtherInformation };
            _context.EarlyCompletions.Add(newEarlyCompletions);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/EarlyCompletions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EarlyCompletion>> DeleteEarlyCompletion(int id)
        {
            var earlyCompletion = await _context.EarlyCompletions.FindAsync(id);
            if (earlyCompletion == null)
            {
                return NotFound();
            }

            _context.EarlyCompletions.Remove(earlyCompletion);
            await _context.SaveChangesAsync();

            return earlyCompletion;
        }

        private bool EarlyCompletionExists(int id)
        {
            return _context.EarlyCompletions.Any(e => e.EarlyCompletionId == id);
        }
    }
}
