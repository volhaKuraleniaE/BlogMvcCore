﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BlogMvcCore.Storage
{
    public class DbContext : IdentityDbContext<IdentityUser>
    {
        public DbContext(DbContextOptions<DbContext> options)
                           : base(options) { Database.EnsureCreated(); }
        public DbSet<User> BlogUsers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasIndex(l => l.Login).
                       IsUnique();
            });
            base.OnModelCreating(builder);
        }
    }
}