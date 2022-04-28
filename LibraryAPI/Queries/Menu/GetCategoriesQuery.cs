using Library.Models.DTO.Models.Dishes;
using MediatR;

namespace LibraryAPI.Queries.Menu
{
    public class GetCategoriesQuery : IRequest<IEnumerable<DishCategoryDTO>>
    {

    }
}
