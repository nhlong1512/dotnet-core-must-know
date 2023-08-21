using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PatchAPI.Dtos.RequestDtos;
using PatchAPI.Dtos.Response;
using PatchAPI.Services.Interfaces;

namespace PatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAllBooks")]
        public async ValueTask<IActionResult> GetAllBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong.");
            }
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpPatch("UpdateBookPatch/{bookId}")]
        public async ValueTask<IActionResult> UpdateBookPatch(Guid bookId, JsonPatchDocument<BookRequest> bookPatch)
        {
            if (!await _bookService.CheckBookExistAsync(bookId))
            {
                return NotFound("Book is not exist.");
            }
            BookResponse bookResponse = await _bookService.UpdateBookPatchByIdAsync(bookId, bookPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(bookResponse);
        }
    }
}
