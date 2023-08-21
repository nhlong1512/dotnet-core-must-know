using AutoMapper;
using RepositoryPatternCRUD.Data;
using RepositoryPatternCRUD.Data.Models;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;
using RepositoryPatternCRUD.Repositories.Implementations;
using RepositoryPatternCRUD.Repositories.Interfaces;
using RepositoryPatternCRUD.Services.Interfaces;

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

        public async ValueTask<bool> CheckBookExistAsync(Guid bookId)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookId);
            return book != null;
        }
    }
}
