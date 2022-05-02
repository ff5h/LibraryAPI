using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetMainKeyboardMarkupQueryHandler : IRequestHandler<GetMainKeyboardMarkupQuery, IReplyMarkup>
    {
        public async Task<IReplyMarkup> Handle(GetMainKeyboardMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new[]
            {
                new KeyboardButton[] { "Меню", "Кошик", "Інформація" },
                new KeyboardButton[] { "Створити карту постійного клієнта" },
            };

            var keyboard = new ReplyKeyboardMarkup(buttons)
            {
                ResizeKeyboard = true,
                OneTimeKeyboard = false
            };
            return keyboard;
        }
    }
}
