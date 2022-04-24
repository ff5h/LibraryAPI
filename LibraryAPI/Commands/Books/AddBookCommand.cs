using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Books
{
    //The command expects AddBookResponseDTO and stores these fields
    public class AddBookCommand : IRequest<AddBookResponseDTO>
    {
        public string Title { get; init; }
        public string Author { get; init; }
        public string Publisher { get; init; }
        public int Pages { get; init; }
        public float Price { get; init; }
    }
}
