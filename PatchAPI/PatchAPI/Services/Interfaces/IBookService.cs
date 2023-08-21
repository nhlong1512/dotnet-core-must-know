using Microsoft.AspNetCore.JsonPatch;
using PatchAPI.Dtos.RequestDtos;
using PatchAPI.Dtos.Response;

namespace PatchAPI.Services.Interfaces
{
    public interface IBookService
    {
        ValueTask<ICollection<BookResponse>> GetAllBooksAsync();
        ValueTask<BookResponse> UpdateBookPatchByIdAsync(Guid bookId, JsonPatchDocument<BookRequest> bookPatch);
        ValueTask<bool> CheckBookExistAsync(Guid bookId);
    }
}
