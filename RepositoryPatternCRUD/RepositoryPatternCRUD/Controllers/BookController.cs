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
    }
}
