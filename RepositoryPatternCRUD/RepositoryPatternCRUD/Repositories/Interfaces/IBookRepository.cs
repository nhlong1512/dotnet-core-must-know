using Microsoft.AspNetCore.JsonPatch;
using RepositoryPatternCRUD.Data.Models;

namespace RepositoryPatternCRUD.Repositories.Interfaces
{
    public interface IBookRepository
    {
        ValueTask<ICollection<Book>> GetAllBooksAsync();
        ValueTask<Book> GetBookByIdAsync(Guid bookId);
        ValueTask<Book> CreateBookAsync(Book book);
        ValueTask<Book> UpdateBookByIdAsync(Guid bookId, Book book);
        ValueTask<bool> DeleteBookByIdAsync(Guid bookId);
    }
}
