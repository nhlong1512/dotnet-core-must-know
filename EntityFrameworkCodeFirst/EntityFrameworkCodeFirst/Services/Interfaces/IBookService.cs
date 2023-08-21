using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst.Services.Interfaces
{
    public interface IBookService
    {
        ValueTask<ICollection<Book>> GetAllBooksAsync();
    }
}
