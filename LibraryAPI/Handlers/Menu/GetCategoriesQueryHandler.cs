using AutoMapper;
using Library.Models.DTO.Models.Dishes;
using Library.Repository.Interfaces;
using Library.Repository.Models;
using LibraryAPI.Queries.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Menu
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<DishCategoryDTO>>
    {
        private readonly IAppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(IAppDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishCategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categoriesQuery = _ctx.DishCategories.AsQueryable();
            var categoriesArray = await categoriesQuery.ToArrayAsync();
            var result = _mapper.Map<IEnumerable<DishCategory>, DishCategoryDTO[]>(categoriesArray);
            return result;
        }
    }
}
