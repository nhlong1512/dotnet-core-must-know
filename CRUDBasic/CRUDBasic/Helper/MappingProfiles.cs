using AutoMapper;
using CRUDBasic.Data.Models;
using CRUDBasic.Dtos.RequestDtos;
using CRUDBasic.Dtos.Response;

namespace CRUDBasic.Helper
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
