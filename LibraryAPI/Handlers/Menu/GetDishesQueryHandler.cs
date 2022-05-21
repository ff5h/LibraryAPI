using AutoMapper;
using Library.Models.DTO.Models.Dishes;
using Library.Repository.Interfaces;
using Library.Repository.Models;
using LibraryAPI.Queries.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Menu
{
    public class GetDishesQueryHandler : IRequestHandler<GetDishesQuery, IEnumerable<DishDTO>>
    {
        private readonly IAppDBContext _ctx;
        private readonly IMapper _mapper;

        public GetDishesQueryHandler(IAppDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DishDTO>> Handle(GetDishesQuery request, CancellationToken cancellationToken)
        {
            var dishesQuery = _ctx.Dishes.Include(d => d.Category).AsQueryable();
            var dishesArray = await dishesQuery.ToArrayAsync();
            var result = _mapper.Map<IEnumerable<Dish>, DishDTO[]>(dishesArray);
            return result;
        }
    }
}
