using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rabbit.Api.Data;
using Rabbit.Api.Models;

namespace Rabbit.Api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class ArticleController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ArticleController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAllPosts()
        {
            var posts = await _context.Posts.ToListAsync();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(int id)
        {
            var post = await _context.Posts
                .Include(p => p.User) 
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post); 
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllPosts), new { id = post.PostId }, post);
        }
    }
}
