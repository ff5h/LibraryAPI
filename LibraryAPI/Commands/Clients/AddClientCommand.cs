using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Clients
{
    public class AddClientCommand : IRequest<AddClientResponseDTO>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string MiddleName { get; init; }
    }
}
