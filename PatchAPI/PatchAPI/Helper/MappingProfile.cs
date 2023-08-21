using AutoMapper;
using PatchAPI.Data.Models;
using PatchAPI.Dtos.RequestDtos;
using PatchAPI.Dtos.Response;

namespace PatchAPI.Helper
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
