using AutoMapper;
using Library.Models.DTO.Models.Books;
using LibraryAPI.Data;
using LibraryAPI.Data.Models;
using LibraryAPI.Queries.Books;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Books
{
    //Какой запрос обрабатываю, и что должен вернуть
    public class GetBookQueryHandler : IRequestHandler<GetBooksQuery, IEnumerable<BookDTO>>
    {
        private readonly AppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(AppDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDTO>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var booksArray = await _ctx.Books.ToArrayAsync();
            var result = _mapper.Map<IEnumerable<Book>, BookDTO[]>(booksArray);
            return result;
        }
    }
}
