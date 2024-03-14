using Catalog.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Catalog.Api
{
    public class Context : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public Context(DbContextOptions<Context> options) : base(options: options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
               new Item { Id = 1, Name = "Item 1", Description = "Description 1" },
               new Item { Id = 2, Name = "Item 2", Description = "Description 2" },
               new Item { Id = 3, Name = "Item 3", Description = "Description 3" }
            );
        }

    }
}
