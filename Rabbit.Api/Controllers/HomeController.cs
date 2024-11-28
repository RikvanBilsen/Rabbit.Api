using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rabbit.Api.Data;
using Rabbit.Api.DTOs;
using Rabbit.Api.Models;

namespace Rabbit.Api.Controllers
{
    [ApiController]
    [Route("api/post")]
    public class HomeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
        {
            var posts = await _context.Posts
                .Include(p => p.User) 
                .ToListAsync();
            
            var postDtos = posts.Select(post => new PostDto
            {
                PostId = post.PostId,
                Title = post.Title,
                Body = post.Body,
                PublishDate = post.PublishDate,
                LastEdited = post.LastEdited,
                Tag = post.Tag,
                User = new UserDto
                {
                    UserId = post.User.UserId,
                    UserName = post.User.UserName,
                    Email = post.User.Email,
                    PasswordHash = post.User.PasswordHash
                }
            }).ToList();

            return Ok(postDtos);
        }

        [HttpGet("{postId}")]
        public async Task<IActionResult> GetPostById(int postId)
        {
            var post = await _context.Posts
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.PostId == postId);

            if (post == null)
            {
                return NotFound();
            }

            var postDto = new PostDto
            {
                PostId = post.PostId,
                Title = post.Title,
                Body = post.Body,
                PublishDate = post.PublishDate,
                LastEdited = post.LastEdited,
                Tag = post.Tag,
                User = new UserDto
                {
                    UserId = post.User.UserId,
                    UserName = post.User.UserName,
                    Email = post.User.Email,
                    PasswordHash = post.User.PasswordHash
                    
                }
            };

            return Ok(postDto);
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