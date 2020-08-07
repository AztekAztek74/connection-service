using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models.Tariff;
using backend.Interface;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TariffsController : ControllerBase
    {
        private readonly TariffContext _context;

        public TariffsController(TariffContext context)
        {
            _context = context;
        }

        // GET: api/Tariffs
        [HttpGet]
        public IEnumerable<TariffGet> GetTariffs(string City)
        {
            return (from item in _context.Tariffs
                          where item.AccessibleCities.Contains(City)
                          select new TariffGet()
                          {
                              ServiceName = item.ServiceName,
                              ServicePrice = item.ServicePrice,
                              ServiceDescription = item.ServiceDescription
                          }
                        ).ToList();
        }

        // GET: api/Tariffs/5
        [HttpGet("{id}")]
        public IEnumerable<TariffGet> GetTariff(string id)
        {


            return (from item in _context.Tariffs
                    where item.AccessibleCities.Contains(id)
                    select new TariffGet()
                    {
                        ServiceName = item.ServiceName,
                        ServicePrice = item.ServicePrice,
                        ServiceDescription = item.ServiceDescription
                    }
                        ).ToList(); 
        }

        // PUT: api/Tariffs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTariff(string id, Tariff tariff)
        {
            if (id != tariff.ServiceName)
            {
                return BadRequest();
            }

            _context.Entry(tariff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TariffExists(id))
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

        // POST: api/Tariffs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tariff>> PostTariff(Tariff tariff)
        {
            _context.Tariffs.Add(tariff);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TariffExists(tariff.ServiceName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTariff", new { id = tariff.ServiceName }, tariff);
        }

        // DELETE: api/Tariffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tariff>> DeleteTariff(string id)
        {
            var tariff = await _context.Tariffs.FindAsync(id);
            if (tariff == null)
            {
                return NotFound();
            }

            _context.Tariffs.Remove(tariff);
            await _context.SaveChangesAsync();

            return tariff;
        }

        private bool TariffExists(string id)
        {
            return _context.Tariffs.Any(e => e.ServiceName == id);
        }
    }
}
