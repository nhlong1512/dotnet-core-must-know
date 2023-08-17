using EntityFrameworkDatabaseFirst.Data;
using EntityFrameworkDatabaseFirst.Data.Models;
using EntityFrameworkDatabaseFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDatabaseFirst.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;

        public BookService(DataContext context)
        {
            _context = context;
        }
        public async ValueTask<IEnumerable<Book>> GetAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }
    }
}

