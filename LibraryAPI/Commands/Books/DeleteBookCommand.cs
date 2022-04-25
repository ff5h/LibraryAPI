using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Books
{
    public class DeleteBookCommand : IRequest<DeleteBookResponseDTO>
    {
        public int Id { get; init; }
    }
}
