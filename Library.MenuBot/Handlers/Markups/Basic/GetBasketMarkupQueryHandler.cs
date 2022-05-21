using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Handlers.Markups.Basic
{
    public class GetBasketMarkupQueryHandler : IRequestHandler<GetBasketMarkupQuery, IMarkup>
    {
        public async Task<IMarkup> Handle(GetBasketMarkupQuery request, CancellationToken cancellationToken)
        {
            var buttons = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>
                {
                    { "Купити", "AddBasket" },
                },

                new Dictionary<string, string>
                {
                    { "Очистити", "Clear" },
                    { "Видалити", "Remove" },
                },

                new Dictionary<string, string>
                {
                    { "<-", "Pr" },
                    { "Шт. 0", "Quan" },
                    { "->", "Ne" },
                },

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
