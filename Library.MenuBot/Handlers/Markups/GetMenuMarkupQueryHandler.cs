using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetMenuMarkupQueryHandler : IRequestHandler<GetMenuMarkupQuery, IReplyMarkup>
    {
        public async Task<IReplyMarkup> Handle(GetMenuMarkupQuery request, CancellationToken cancellationToken)
        {
            int previousId = request.CurrentPossition == 0
                         ? request.DishCount - 1
                         : request.CurrentPossition - 1;
            int nextId = request.CurrentPossition + 1 < request.DishCount
                         ? request.CurrentPossition + 1
                         : 0;


            var buttons = new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Назад", $"Menu {request.CategoryId} {previousId}"),
                    InlineKeyboardButton.WithCallbackData("До меню", "Categories"),
                    InlineKeyboardButton.WithCallbackData("Купити", $"Buy {request.DishId}"),
                    InlineKeyboardButton.WithCallbackData("Вперед", $"Menu {request.CategoryId} {nextId}"),
                },
            };
            var markup = new InlineKeyboardMarkup(buttons);
            return markup;
        }
    }
}
