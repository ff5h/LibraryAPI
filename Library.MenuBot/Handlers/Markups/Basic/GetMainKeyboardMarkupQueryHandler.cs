using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Handlers.Markups.Basic
{
    public class GetMainKeyboardMarkupQueryHandler : IRequestHandler<GetMainKeyboardMarkupQuery, IMarkup>
    {
        public async Task<IMarkup> Handle(GetMainKeyboardMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new string[][]
            {
                new string[] { "Меню", "Кошик" },
                new string[] { "Інформація" }
            };

            var keyboard = new KeyboardReplyMarkup(buttons, true);
            return keyboard;
        }
    }
}
