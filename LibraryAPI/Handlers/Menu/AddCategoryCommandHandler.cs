using Library.Models.DTO.Responses;
using Library.Repository.Interfaces;
using Library.Repository.Models;
using LibraryAPI.Commands.Menu;
using MediatR;

namespace LibraryAPI.Handlers.Menu
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public AddCategoryCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<AddCategoryResponseDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new DishCategory()
            {
                Name = request.Name,
            };

            _ctx.DishCategories.Add(category);
            await _ctx.SaveChangesAsync();
            var result = new AddCategoryResponseDTO()
            {
                Id = category.Id,
            };
            return result;
        }
    }
}
