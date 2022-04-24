using AutoMapper;
using Library.Models.DTO.Models.Book;
using LibraryAPI.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly IMapper _mapper;

        public BookController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet("GetBooks")]
        public async Task<IEnumerable<BookDTO>> GetBooks()
        {
            var query = new GetBooksQuery();
            var result = await _sender.Send(query);
            return result;
        }
    }
}