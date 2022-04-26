using AutoMapper;
using Library.Models.DTO.Models.Books;
using Library.Models.DTO.Requests;
using LibraryAPI.Commands.Books;
using Library.Repository.Models;

namespace LibraryAPI.MapperProfiles
{
    public class BookMapperProfile : Profile
    {
        public BookMapperProfile()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<AddBookRequestDTO, AddBookCommand>();
            CreateMap<DeleteBookRequestDTO, DeleteBookCommand>();
        }
    }
}
