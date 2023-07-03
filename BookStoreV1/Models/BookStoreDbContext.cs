using Microsoft.EntityFrameworkCore;

namespace BookStoreV1.Models
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

    }
}
