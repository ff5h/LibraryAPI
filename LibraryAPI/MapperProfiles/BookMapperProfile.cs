using AutoMapper;
using Library.Models.DTO.Models.Book;
using Library.Models.DTO.Requests;
using LibraryAPI.Commands.Books;
using LibraryAPI.Data.Models;

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
