using Microsoft.EntityFrameworkCore;
using NewsLand.Domain;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace NewsLand.Persistence
{
    public class PostDbContext : DbContext
    {
        public PostDbContext(DbContextOptions<PostDbContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var categoryGuid = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var postGuid = Guid.Parse("22222222-2222-2222-2222-222222222222");
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = categoryGuid,
                Name = "Technology"
            });
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = postGuid,
                Title = "Introduction in CQRS and Mediator Design Pattern",
                Content = "opgmtrpm4tpo4gkm4[4ojo6gjk4-bj  jk -jk4 -4jk -[ o40kj45vj4",
                ImageUrl = "",
                CategoryId = categoryGuid
            });                       
        }
    }
}
