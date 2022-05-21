using Library.Models.DTO.Responses;
using Library.Repository.Interfaces;
using LibraryAPI.Commands.Menu;
using MediatR;

namespace LibraryAPI.Handlers.Menu
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponseDTO>
    {
        private readonly IAppDBContext _ctx;

        public DeleteCategoryCommandHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<DeleteCategoryResponseDTO> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoriesQuery = _ctx.DishCategories.AsQueryable();
            categoriesQuery = categoriesQuery.Where(c => c.Id == request.Id);
            var category = categoriesQuery.FirstOrDefault();
            _ctx.DishCategories.Remove(category);
            await _ctx.SaveChangesAsync();
            var result = new DeleteCategoryResponseDTO()
            {
                Name = category.Name,
            };
            return result;
        }
    }
}
