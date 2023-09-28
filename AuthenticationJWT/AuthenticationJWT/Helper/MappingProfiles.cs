using AuthenticationJWT.Data.Models;
using AuthenticationJWT.Dtos.RequestDtos;
using AuthenticationJWT.Dtos.ResponseDtos;
using AutoMapper;

namespace AuthenticationJWT.Helper
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
