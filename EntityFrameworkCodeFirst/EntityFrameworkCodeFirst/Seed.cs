using EntityFrameworkCodeFirst.Data;
using EntityFrameworkCodeFirst.Models;

namespace EntityFrameworkCodeFirst
{
    public class Seed
    {
        private readonly DataContext _context;

        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedDataContext()
        {
            var books = new List<Book>()
            {
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Sorcerer’s Stone",
                    TotalPages = 441,
                    Rating = 4.9M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Chamber of Secrets",
                    TotalPages = 398,
                    Rating = 4.8M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    TotalPages = 453,
                    Rating = 4.85M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Goblet of Fire",
                    TotalPages = 412,
                    Rating = 4.83M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Order of the Phoenix",
                    TotalPages = 471,
                    Rating = 4.92M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Half-blood Prince",
                    TotalPages = 376,
                    Rating = 4.88M,
                    IsDeleted = false,
                    IdPublished = true,
                },
                new Book ()
                {
                    BookId = Guid.NewGuid(),
                    Title = "Harry Potter and the Deathly Hallows",
                    TotalPages = 550,
                    Rating = 4.97M,
                    IsDeleted = false,
                    IdPublished = true,
                },
            };
            _context.Book.AddRange(books);
            _context.SaveChanges();
        }
    }
}
