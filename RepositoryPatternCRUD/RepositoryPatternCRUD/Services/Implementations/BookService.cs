using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using RepositoryPatternCRUD.Data;
using RepositoryPatternCRUD.Data.Models;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;
using RepositoryPatternCRUD.Repositories.Implementations;
using RepositoryPatternCRUD.Repositories.Interfaces;
using RepositoryPatternCRUD.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternCRUD.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;

        public BookService(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async ValueTask<ICollection<BookResponse>> GetAllBooksAsync()
        {
            ICollection<Book> books = await _bookRepository.GetAllBooksAsync();
            ICollection<BookResponse> booksReponse = _mapper.Map<ICollection<BookResponse>>(books);
            return booksReponse;
        }

        public async ValueTask<BookResponse> GetBookByIdAsync(Guid bookId)
        {
            Book book = await _bookRepository.GetBookByIdAsync(bookId);
            return _mapper.Map<BookResponse>(book);
        }

        public async ValueTask<BookResponse> CreateBookAsync(BookRequest bookRequest)
        {
            Book book = _mapper.Map<Book>(bookRequest);
            Book createdBook = await _bookRepository.CreateBookAsync(book);
            return _mapper.Map<BookResponse>(createdBook);
        }

        public async ValueTask<BookResponse> UpdateBookByIdAsync(Guid bookId, BookRequest bookRequest)
        {
            Book book = await _bookRepository.GetBookByIdAsync(bookId);
            if (book == null)
            {
                throw new Exception();
            }
            await _bookRepository.UpdateBookByIdAsync(bookId, _mapper.Map<Book>(bookRequest));
            return _mapper.Map<BookResponse>(book);
        }

        public async ValueTask<bool> DeleteBookByIdAsync(Guid bookId)
        {
            bool isDeleted = await _bookRepository.DeleteBookByIdAsync(bookId);
            return isDeleted;
        }
        public async ValueTask<BookResponse> UpdateBookPatchByIdAsync(Guid bookId, JsonPatchDocument<BookRequest> bookPatch)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(bookId);
            if (existingBook == null)
            {
                throw new Exception("Book not found.");
            }
            var bookRequest = _mapper.Map<BookRequest>(existingBook);
            bookPatch.ApplyTo(bookRequest);
            _mapper.Map(bookRequest, existingBook);
            await _bookRepository.UpdateBookByIdAsync(bookId, existingBook);
            return _mapper.Map<BookResponse>(existingBook);
        }

        public async ValueTask<bool> CheckBookExistAsync(Guid bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            return book != null;
        }

    }
}
