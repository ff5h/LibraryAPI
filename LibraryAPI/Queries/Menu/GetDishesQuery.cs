using Library.Models.DTO.Models.Dishes;
using MediatR;

namespace LibraryAPI.Queries.Menu
{
    public class GetDishesQuery : IRequest<IEnumerable<DishDTO>>
    {

    }
}
