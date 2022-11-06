using Microsoft.EntityFrameworkCore;
using BookstoreApi.Models;
using System;

namespace BookstoreApi.DBContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
