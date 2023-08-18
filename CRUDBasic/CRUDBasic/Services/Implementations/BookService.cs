using AutoMapper;
using CRUDBasic.Data;
using CRUDBasic.Data.Models;
using CRUDBasic.Dtos.RequestDtos;
using CRUDBasic.Dtos.Response;
using CRUDBasic.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace CRUDBasic.Services.Implementations
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

        public async ValueTask<BookResponse> GetBookByIdAsync(Guid bookId)
        {
            var book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            return _mapper.Map<BookResponse>(book);
        }

        public async ValueTask<BookResponse> CreateBookAsync(BookRequest bookRequest)
        {
            Book book = _mapper.Map<Book>(bookRequest);
            book.BookId = Guid.NewGuid();
            book.IsDeleted = false;
            book.IsPublished = true;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookResponse>(book);
        }

        public async ValueTask<BookResponse> UpdateBookByIdAsync(Guid bookId, BookRequest bookRequest)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new Exception();
            }
            book.Title = bookRequest.Title;
            book.TotalPages = bookRequest.TotalPages;
            book.Rating = bookRequest.Rating;
            await _context.SaveChangesAsync();
            return _mapper.Map<BookResponse>(book);
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

        public async ValueTask<bool> DeleteBookByIdAsync(Guid bookId)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            if (book == null)
            {
                throw new Exception();
            }
            book.IsDeleted = true;
            return await _context.SaveChangesAsync() > 0;
        }

        public async ValueTask<bool> CheckBookExistAsync(Guid bookId)
        {
            Book book = await _context.Books.Where(b => b.IsDeleted == false && b.IsPublished == true && b.BookId == bookId).FirstOrDefaultAsync();
            return book != null;
        }
    }
}
