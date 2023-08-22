using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;
using RepositoryPatternCRUD.Services.Interfaces;

namespace RepositoryPatternCRUD.Controllers
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

        [HttpGet("GetBookById/{bookId}")]
        public async ValueTask<IActionResult> GetBookById(Guid bookId)
        {
            if (!await _bookService.CheckBookExistAsync(bookId))
            {
                return NotFound("Book is not exist.");
            }
            BookResponse book = await _bookService.GetBookByIdAsync(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async ValueTask<IActionResult> CreateBook(BookRequest bookRequest)
        {
            BookResponse book = await _bookService.CreateBookAsync(bookRequest);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(book);
        }

        [HttpPut("UpdateBook/{bookId}")]
        public async ValueTask<IActionResult> UpdateBook(Guid bookId, BookRequest bookRequest)
        {
            if (!await _bookService.CheckBookExistAsync(bookId))
            {
                return NotFound("Book is not exist.");
            }
            BookResponse book = await _bookService.UpdateBookByIdAsync(bookId, bookRequest);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong.");
            }
            return Ok(book);
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

        [HttpDelete("DeleteBook/{bookId}")]
        public async ValueTask<IActionResult> DeleteBook(Guid bookId)
        {
            if (!await _bookService.CheckBookExistAsync(bookId))
            {
                return NotFound("Book is not exist.");
            }
            bool isDeleted = await _bookService.DeleteBookByIdAsync(bookId);
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(isDeleted ? "Deleted successfully." : "Delete failed.");
        }
    }
}
