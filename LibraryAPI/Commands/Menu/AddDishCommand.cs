using Library.Models.DTO.Responses;
using Library.Repository.Models;
using MediatR;

namespace LibraryAPI.Commands.Menu
{
    public class AddDishCommand : IRequest<AddDishResponseDTO>
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public double Price { get; set; }
        public int Weight { get; set; }
    }
}
