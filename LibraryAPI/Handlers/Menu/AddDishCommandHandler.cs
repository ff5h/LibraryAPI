using Library.Models.DTO.Responses;
using Library.Repository.Interfaces;
using Library.Repository.Models;
using LibraryAPI.Commands.Menu;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Handlers.Menu
{
    public class AddDishCommandHandler : IRequestHandler<AddDishCommand, AddDishResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public AddDishCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AddDishResponseDTO> Handle(AddDishCommand request, CancellationToken cancellationToken)
        {
            var category = await _ctx.DishCategories.FirstOrDefaultAsync(c => c.Id == request.CategoryId);
            bool hasPhoto = await _ctx.Attachments.AnyAsync(a => a.Id == request.PhotoId);
            if (category == null || !hasPhoto) return new AddDishResponseDTO()
            {
                Id = -1
            };

            var dish = new Dish()
            {
                Name = request.Name,
                Price = request.Price,
                Weight = request.Weight,
                Category = category,
                PhotoId = request.PhotoId
            };
            _ctx.Dishes.Add(dish);
            await _ctx.SaveChangesAsync();
            var result = new AddDishResponseDTO()
            {
                Id = dish.Id
            };
            return result;
        }
    }
}
