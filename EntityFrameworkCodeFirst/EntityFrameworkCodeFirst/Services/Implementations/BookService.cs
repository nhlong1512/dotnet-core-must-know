using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models;
using EntityFrameworkCodeFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCodeFirst.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }
        public async ValueTask<ICollection<Book>> GetAllBooksAsync()
        {
            ICollection<Book> books = await _context.Book.Where(b => b.IsDeleted == false && b.IdPublished == true).ToListAsync();
            return books;
        }
    }
}
