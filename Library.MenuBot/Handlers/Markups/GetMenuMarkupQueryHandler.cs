using Library.MenuBot.Common.Utilities;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetMenuMarkupQueryHandler : IRequestHandler<GetMenuMarkupQuery, IReplyMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetMenuMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReplyMarkup> Handle(GetMenuMarkupQuery request, CancellationToken cancellationToken)
        {
            var categories = await _ctx.DishCategories.ToArrayAsync();
            var categoriesDict = new Dictionary<string, string>(categories.Select(c => new KeyValuePair<string, string>("Menu " + c.Id.ToString(), c.Name)));
            var markup = TelegramUtilities.CreateInlineKeyboardButton(categoriesDict);
            return markup;
        }
    }
}
