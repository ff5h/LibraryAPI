using AutoMapper;
using Library.Models.DTO.Models.Book;
using LibraryAPI.Data.Models;

namespace LibraryAPI.MapperProfiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookDTO>();
        }
    }
}
