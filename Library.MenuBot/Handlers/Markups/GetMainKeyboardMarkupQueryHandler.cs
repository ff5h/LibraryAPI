using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetMainKeyboardMarkupQueryHandler : IRequestHandler<GetMainKeyboardMarkupQuery, ReplyKeyboardMarkup>
    {
        public async Task<ReplyKeyboardMarkup> Handle(GetMainKeyboardMarkupQuery request, CancellationToken cancellationToken)
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
