using Library.MenuBot.Common.Utilities;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Markups.Basic
{
    public class GetCategoriesMarkupQueryHandler : IRequestHandler<GetCategoriesMarkupQuery, IMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetCategoriesMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IMarkup> Handle(GetCategoriesMarkupQuery request, CancellationToken cancellationToken)
        {
            var categories = await _ctx.DishCategories.ToArrayAsync();
            var categoriesDict = new Dictionary<string, string>(categories.Select(c => new KeyValuePair<string, string>(c.Name, $"Menu {c.Id} 0 CategoryMenu")));
            categoriesDict.Add("Головна", "Main");
            var markup = TelegramUtilities.CreateInlineKeyboardButton(categoriesDict);
            return markup;
        }
    }
}
