using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wander_wisdom.Interface;
using Wander_wisdom.Models;

namespace Wander_wisdom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private readonly IUserDetails _context;

        public UserDetailsController(IUserDetails context)
        {
            _context = context;
        }

        // GET: api/UserDetails
        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetUserDetails()
        {
          if (_context.UserDetails == null)
          {
              return NotFound();
          }
            return await _context.UserDetails.ToListAsync();
        }*/

        // GET: api/UserDetails/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUserDetail(int id)
        {
          if (_context.UserDetails == null)
          {
              return NotFound();
          }
            var userDetail = await _context.UserDetails.FindAsync(id);

            if (userDetail == null)
            {
                return NotFound();
            }

            return userDetail;
        }*/

        // PUT: api/UserDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutUserDetail(int id, UserDetail userDetail)
        {
            if (id != userDetail.UserIdPk)
            {
                return BadRequest();
            }

            _context.Entry(userDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/UserDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /* [HttpPost]
         public async Task<ActionResult<UserDetail>> PostUserDetail(UserDetail userDetail)
         {
           if (_context.UserDetails == null)
           {
               return Problem("Entity set 'WanderWisdomContext.UserDetails'  is null.");
           }
             _context.UserDetails.Add(userDetail);
             await _context.SaveChangesAsync();

             return CreatedAtAction("GetUserDetail", new { id = userDetail.UserIdPk }, userDetail);
         }

         // DELETE: api/UserDetails/5
         [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteUserDetail(int id)
         {
             if (_context.UserDetails == null)
             {
                 return NotFound();
             }
             var userDetail = await _context.UserDetails.FindAsync(id);
             if (userDetail == null)
             {
                 return NotFound();
             }

             _context.UserDetails.Remove(userDetail);
             await _context.SaveChangesAsync();

             return NoContent();
         }

         private bool UserDetailExists(int id)
         {
             return (_context.UserDetails?.Any(e => e.UserIdPk == id)).GetValueOrDefault();
         }*/


        [HttpPost("login")]
        public async Task<UserDetail> UserLogin(UserDetail user)
        {
            return await _context.UserLogin(user);
        }

        [HttpPost]

        public async Task<string> UserRegistration(UserDetail user)
        {
            return await _context.UserRegistration(user);
        }

        [HttpDelete]
        public async Task<string> DeleteUser(int id)
        {
            return await _context.DeleteUser(id);
        }
    }
}
