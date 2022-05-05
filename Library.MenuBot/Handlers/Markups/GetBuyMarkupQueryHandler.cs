using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetBuyMarkupQueryHandler : IRequestHandler<GetBuyMarkupQuery, IReplyMarkup>
    {
        public async Task<IReplyMarkup> Handle(GetBuyMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new[]
            {
                new []
                {
                    InlineKeyboardButton.WithCallbackData("-", $"Buy {request.DishId} {request.Count - 1}"),
                    InlineKeyboardButton.WithCallbackData($"{request.Count}", " "),
                    InlineKeyboardButton.WithCallbackData("+", $"Buy {request.DishId} {request.Count + 1}"),
                },

                new []
                {
                    InlineKeyboardButton.WithCallbackData("Підтвердити", "Confirm"),
                    InlineKeyboardButton.WithCallbackData("Відмінити", "Cancel"),
                },
            };
            var markup = new InlineKeyboardMarkup(buttons);
            return markup;  
        }
    }
}
