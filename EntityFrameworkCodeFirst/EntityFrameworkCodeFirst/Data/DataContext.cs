using EntityFrameworkCodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EntityFrameworkCodeFirst.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasKey(b => new { b.BookId });
        }
    }
    
}
