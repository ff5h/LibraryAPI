using Library.MenuBot.Common.Utilities;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetCategoriesMarkupQueryHandler : IRequestHandler<GetCategoriesMarkupQuery, IReplyMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetCategoriesMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReplyMarkup> Handle(GetCategoriesMarkupQuery request, CancellationToken cancellationToken)
        {
            var categories = await _ctx.DishCategories.ToArrayAsync();
            var categoriesDict = new Dictionary<string, string>(categories.Select(c => new KeyValuePair<string, string>($"Menu {c.Id} 0", c.Name)));
            var markup = TelegramUtilities.CreateInlineKeyboardButton(categoriesDict);
            return markup;
        }
    }
}
