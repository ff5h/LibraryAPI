using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Clients
{
    public class DeleteClientCommand : IRequest<DeleteClientResponseDTO>
    {
        public int Id { get; init; }
    }
}
