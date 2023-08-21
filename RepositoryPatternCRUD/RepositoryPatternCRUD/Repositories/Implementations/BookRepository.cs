using Microsoft.EntityFrameworkCore;
using RepositoryPatternCRUD.Data;
using RepositoryPatternCRUD.Data.Models;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;
using RepositoryPatternCRUD.Repositories.Interfaces;

namespace RepositoryPatternCRUD.Repositories.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async ValueTask<ICollection<Book>> GetAllBooksAsync()
        {
            ICollection<Book> books = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true).ToListAsync();
            return books;
        }

        public async ValueTask<Book> GetBookByIdAsync(Guid bookId)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            return book;
        }

        public async ValueTask<Book> CreateBookAsync(Book book)
        {
            book.BookId = Guid.NewGuid();
            book.IsDeleted = false;
            book.IsPublished = true;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        //public async ValueTask<Book> UpdateBookAsync(Guid bookId, Book book)
        //{
        //    _context.Books.Update(book);
        //    await _context.SaveChangesAsync() > 0;
        //}

        public ValueTask<bool> DeleteBookAsync(Guid bookId)
        {
            throw new NotImplementedException();
        }
    }
}
