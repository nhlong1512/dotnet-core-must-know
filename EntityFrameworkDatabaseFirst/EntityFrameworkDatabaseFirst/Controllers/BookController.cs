using EntityFrameworkDatabaseFirst.Data;
using EntityFrameworkDatabaseFirst.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkDatabaseFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController: ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly DataContext _context;

        public BookController(IBookService bookService, DataContext context)
        {
            _bookService = bookService;
            _context = context;
        }

        [HttpGet("")]
        public async ValueTask<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

    }
}
