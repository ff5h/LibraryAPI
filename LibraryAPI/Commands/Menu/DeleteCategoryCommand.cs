using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Menu
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResponseDTO>
    {
        public int Id { get; init; }
    }
}
