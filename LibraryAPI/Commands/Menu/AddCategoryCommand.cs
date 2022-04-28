using Library.Models.DTO.Responses;
using MediatR;

namespace LibraryAPI.Commands.Menu
{
    public class AddCategoryCommand : IRequest<AddCategoryResponseDTO>
    {
        public string Name { get; init; }
    }
}
