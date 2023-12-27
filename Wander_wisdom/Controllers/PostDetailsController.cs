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
    public class PostDetailsController : ControllerBase
    {
        private readonly IPostDetails _context;

        public PostDetailsController(IPostDetails context)
        {
            _context = context;
        }

        // GET: api/PostDetails
        [HttpGet("{id}")]
        public Task<IEnumerable<PostDetail>> GetPostDetails(int id)
        {
            return  _context.GetPost(id);
        }


        [HttpGet]
        public Task<IEnumerable<PostDetail>> GetAllPostDetails()
        {
            return _context.GetAllPost();
        }

        [HttpPost]
        public Task<string> AddPostDeatils(PostDetail post)
        {
            return _context.AddPost(post);
        }

        // GET: api/PostDetails/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<PostDetail>> GetPostDetail(int id)
        {
          if (_context.PostDetails == null)
          {
              return NotFound();
          }
            var postDetail = await _context.PostDetails.FindAsync(id);

            if (postDetail == null)
            {
                return NotFound();
            }

            return postDetail;
        }

        // PUT: api/PostDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPostDetail(int id, PostDetail postDetail)
        {
            if (id != postDetail.PostId)
            {
                return BadRequest();
            }

            _context.Entry(postDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostDetailExists(id))
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

        // POST: api/PostDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PostDetail>> PostPostDetail(PostDetail postDetail)
        {
          if (_context.PostDetails == null)
          {
              return Problem("Entity set 'WanderWisdomContext.PostDetails'  is null.");
          }
            _context.PostDetails.Add(postDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPostDetail", new { id = postDetail.PostId }, postDetail);
        }

        // DELETE: api/PostDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostDetail(int id)
        {
            if (_context.PostDetails == null)
            {
                return NotFound();
            }
            var postDetail = await _context.PostDetails.FindAsync(id);
            if (postDetail == null)
            {
                return NotFound();
            }

            _context.PostDetails.Remove(postDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostDetailExists(int id)
        {
            return (_context.PostDetails?.Any(e => e.PostId == id)).GetValueOrDefault();
        }*/
    }
}
