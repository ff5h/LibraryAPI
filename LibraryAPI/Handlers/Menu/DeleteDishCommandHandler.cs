using Library.Models.DTO.Responses;
using Library.Repository.Interfaces;
using LibraryAPI.Commands.Menu;
using MediatR;

namespace LibraryAPI.Handlers.Menu
{
    public class DeleteDishCommandHandler : IRequestHandler<DeleteDishCommand, DeleteDishResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public DeleteDishCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DeleteDishResponseDTO> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var dishesQuery = _ctx.Dishes.AsQueryable();
            dishesQuery = dishesQuery.Where(c => c.Id == request.Id);
            var dish = dishesQuery.FirstOrDefault();
            _ctx.Dishes.Remove(dish);
            await _ctx.SaveChangesAsync();
            var result = new DeleteDishResponseDTO()
            {
                Name = dish.Name,
            };
            return result;
        }
    }
}
