using Library.Models.DTO.Responses;
using LibraryAPI.Commands.Books;
using MediatR;
using Library.Repository.Interfaces;

namespace LibraryAPI.Handlers.Books
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, DeleteBookResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public DeleteBookCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DeleteBookResponseDTO> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var booksQuery = _ctx.Books.AsQueryable();
            booksQuery = booksQuery.Where(b =>b.Id == request.Id);
            var book = booksQuery.FirstOrDefault();
            _ctx.Books.Remove(book);
            await _ctx.SaveChangesAsync();
            var result = new DeleteBookResponseDTO()
            {
                Title = book.Title,
            };
            return result;
        }
    }
}
