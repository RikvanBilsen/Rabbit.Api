﻿using Microsoft.EntityFrameworkCore;
using Rabbit.Api.Models;

namespace Rabbit.Api.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public  DbSet<Post> Posts { get; set; } 
    }
}