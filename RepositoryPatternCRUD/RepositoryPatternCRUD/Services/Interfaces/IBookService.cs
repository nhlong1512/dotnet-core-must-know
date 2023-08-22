using Microsoft.AspNetCore.JsonPatch;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;

namespace RepositoryPatternCRUD.Services.Interfaces
{
    public interface IBookService
    {
        ValueTask<ICollection<BookResponse>> GetAllBooksAsync();
        ValueTask<BookResponse> GetBookByIdAsync(Guid bookId);
        ValueTask<BookResponse> CreateBookAsync(BookRequest bookRequest);
        ValueTask<BookResponse> UpdateBookByIdAsync(Guid bookId, BookRequest bookRequest);
        ValueTask<BookResponse> UpdateBookPatchByIdAsync(Guid bookId, JsonPatchDocument<BookRequest> bookPatch);
        ValueTask<bool> DeleteBookByIdAsync(Guid bookId);
        ValueTask<bool> CheckBookExistAsync(Guid bookId);
    }
}
