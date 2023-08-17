using EntityFrameworkDatabaseFirst.Data.Models;

namespace EntityFrameworkDatabaseFirst.Services.Interfaces
{
    public interface IBookService
    {
        ValueTask<IEnumerable<Book>> GetAllBooksAsync();
    }
}
