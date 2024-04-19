using Microsoft.EntityFrameworkCore;
using MyLibrary.Domain.Entities;

namespace MyLibrary.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Solo Leveling",
                    Description = "",
                    Author = "Chugong",
                    Pages = 320,
                    CurrentPage = 143,
                },
                new Book
                {
                    Id = 2,
                    Title = "Death Note",
                    Description = "",
                    Author = "Tsugumi Ohba",
                    Pages = 2400,
                    CurrentPage = 629,
                },
                new Book
                {
                    Id = 3,
                    Title = "JoJo's Bizarre Adventure Part 6: Stone Ocean",
                    Description = "",
                    Author = "Hirohiko Araki",
                    Pages = 3260,
                    CurrentPage = 1204,
                }
            );
        }
    }
}

