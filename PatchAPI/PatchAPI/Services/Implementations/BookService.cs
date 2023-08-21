using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using PatchAPI.Data;
using PatchAPI.Data.Models;
using PatchAPI.Dtos.RequestDtos;
using PatchAPI.Dtos.Response;
using PatchAPI.Services.Interfaces;

namespace PatchAPI.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public BookService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async ValueTask<ICollection<BookResponse>> GetAllBooksAsync()
        {
            ICollection<Book> books = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true).ToListAsync();
            ICollection<BookResponse> booksResponse = _mapper.Map<ICollection<BookResponse>>(books);
            return booksResponse;
        }
        public async ValueTask<BookResponse> UpdateBookPatchByIdAsync(Guid bookId, JsonPatchDocument<BookRequest> bookPatch)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            BookRequest bookRequest = _mapper.Map<BookRequest>(book);
            if (book == null)
            {
                throw new Exception();
            }
            bookPatch.ApplyTo(bookRequest);
            _mapper.Map(bookRequest, book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookResponse>(book);
        }

        public async ValueTask<bool> CheckBookExistAsync(Guid bookId)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            return book != null;
        }

    }
}
