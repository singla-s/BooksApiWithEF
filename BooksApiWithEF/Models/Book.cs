using System;
using Microsoft.EntityFrameworkCore;

namespace BooksApiWithEF.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }

    }

    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options): base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}
