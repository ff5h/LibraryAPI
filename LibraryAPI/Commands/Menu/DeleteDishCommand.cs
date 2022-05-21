using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Menu
{
    public class DeleteDishCommand : IRequest<DeleteDishResponseDTO>
    {
        public int Id { get; init; }
    }
}
