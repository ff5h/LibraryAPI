using Library.MenuBot.Queries.Markups;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetBuyMarkupQueryHandler : IRequestHandler<GetBuyMarkupQuery, IMarkup>
    {
        public async Task<IMarkup> Handle(GetBuyMarkupQuery request, CancellationToken cancellationToken)
        {
            //var buttons = new[]
            //{
            //    new []
            //    {
            //        InlineKeyboardButton.WithCallbackData("-", $"Buy {request.DishId} {request.Count - 1}"),
            //        new InlineKeyboardButton($"{request.Count}"),
            //        InlineKeyboardButton.WithCallbackData("+", $"Buy {request.DishId} {request.Count + 1}"),
            //    },

            //    new []
            //    {
            //        InlineKeyboardButton.WithCallbackData("Підтвердити", "Confirm"),
            //        InlineKeyboardButton.WithCallbackData("Відмінити", "Cancel"),
            //    },
            //};

            var buttons = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>
                {
                    { "Головна", "Main" },
                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;  
        }
    }
}
