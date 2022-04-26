using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Books;
using Library.Repository.Models;
using MediatR;
using Library.Repository.Interfaces;

namespace LibraryAPI.Handlers.Books
{
    //The handler expects an AddBookCommand and returns an AddBookResponseDTO
    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, AddBookResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public AddBookCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AddBookResponseDTO> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book()
            {
                Title = request.Title,
                Author = request.Author,
                Publisher = request.Publisher,
                Pages = request.Pages,
                Price = request.Price
            };

            _ctx.Books.Add(book);
            await _ctx.SaveChangesAsync();
            var result = new AddBookResponseDTO()
            {
                Id = book.Id
            };
            return result;
        }
    }
}
