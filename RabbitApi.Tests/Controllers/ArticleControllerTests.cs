using Microsoft.EntityFrameworkCore;
using Rabbit.Api.Controllers;
using Rabbit.Api.Data;
using Rabbit.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rabbit.Api.Tests
{
    public class ArticleControllerTests
    {
        private readonly DatabaseContext _context;
        private readonly ArticleController _controller;

        public ArticleControllerTests()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new DatabaseContext(options);

            // Add initial test data
            _context.Posts.AddRange(new List<Post>
            {
                new Post
                {
                    PostId = 1,
                    Title = "Test Post 1",
                    Body = "Body of Test Post 1",
                    PublishDate = null,
                    LastEdited = DateTime.UtcNow,
                    Tag = "TestTag"
                },
                new Post
                {
                    PostId = 2,
                    Title = "Test Post 2",
                    Body = "Body of Test Post 2",
                    PublishDate = DateTime.UtcNow,
                    LastEdited = DateTime.UtcNow,
                    Tag = "AnotherTag"
                }
            });

            _context.SaveChanges();

            _controller = new ArticleController(_context);
        }

        [Fact]
        public async Task GetAllPosts_ReturnsAllPosts()
        {
            // Act
            var result = await _controller.GetAllPosts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var posts = Assert.IsType<List<Post>>(okResult.Value);

            Assert.Equal(2, posts.Count); 
        }

        [Fact]
        public async Task CreatePost_AddsPostToDatabase()
        {
            // Arrange
            var newPost = new Post
            {
                Title = "New Test Post",
                Body = "Body of New Test Post",
                PublishDate = DateTime.UtcNow,
                LastEdited = DateTime.UtcNow,
                Tag = "NewTag"
            };

            // Act
            var result = await _controller.CreatePost(newPost);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var createdPost = Assert.IsType<Post>(createdAtActionResult.Value);

            Assert.Equal(newPost.Title, createdPost.Title);
            Assert.Equal(newPost.Body, createdPost.Body);

            var postsInDb = await _context.Posts.ToListAsync();
            Assert.Equal(3, postsInDb.Count);
        }
    }
}
