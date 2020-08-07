using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Models.UsersData;
using backend.Interface;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersDatasController : ControllerBase
    {
        private readonly UsersDataContext _context;

        public UsersDatasController(UsersDataContext context)
        {
            _context = context;
        }

        // GET: api/UsersDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersData>>> GetUsersDatas()
        {
            return await _context.UsersDatas.ToListAsync();
        }

        // GET: api/UsersDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersData>> GetUsersData(string id)
        {
            var usersData = await _context.UsersDatas.FindAsync(id);

            if (usersData == null)
            {
                return NotFound();
            }

            return usersData;
        }

        // PUT: api/UsersDatas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersData(string id, UsersData usersData)
        {
            if (id != usersData.Address)
            {
                return BadRequest();
            }

            _context.Entry(usersData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersDataExists(id))
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

        // POST: api/UsersDatas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsersData>> PostUsersData(UsersDataPost usersDataPost)
        {
            var newUsersData = new UsersData { Address = usersDataPost.Address, FullName = usersDataPost.FullName, Phone = usersDataPost.Phone, AdditionalPhone = usersDataPost.AdditionalPhone, HandlingReason = usersDataPost.HandlingReason, Coment = usersDataPost.Coment, SelectedTariffs = usersDataPost.SelectedTariffs };
            _context.UsersDatas.Add(newUsersData);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/UsersDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsersData>> DeleteUsersData(string id)
        {
            var usersData = await _context.UsersDatas.FindAsync(id);
            if (usersData == null)
            {
                return NotFound();
            }

            _context.UsersDatas.Remove(usersData);
            await _context.SaveChangesAsync();

            return usersData;
        }

        private bool UsersDataExists(string id)
        {
            return _context.UsersDatas.Any(e => e.Address == id);
        }
    }
}
