using EntityFrameworkCodeFirst.Models;
using EntityFrameworkCodeFirst.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCodeFirst.Controllers
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
        [ProducesResponseType(200, Type = typeof(ICollection<Book>))]
        public async ValueTask<IActionResult> GetAllBooks()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            ICollection<Book> books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }
    }
}
