using AutoMapper;
using RepositoryPatternCRUD.Data.Models;
using RepositoryPatternCRUD.Dtos.RequestDtos;
using RepositoryPatternCRUD.Dtos.ResponseDtos;

namespace RepositoryPatternCRUD.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookRequest, Book>().ReverseMap();
            CreateMap<Book, BookResponse>();
        }
    }
}
