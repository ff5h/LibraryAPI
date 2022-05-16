using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class InformationMarkupQueryHandler : IRequestHandler<InformationMarkupQuery, InlineKeyboardMarkup>
    {
        public async Task<InlineKeyboardMarkup> Handle(InformationMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("Меню", "Categories"),
                    InlineKeyboardButton.WithCallbackData("Кошик", "Basket"),
                }
            };
            var markup = new InlineKeyboardMarkup(buttons);
            return markup;
        }
    }
}
