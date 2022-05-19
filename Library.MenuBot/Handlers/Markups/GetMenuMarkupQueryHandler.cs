using Library.MenuBot.Queries.Markups;
using Library.Shared.Implementations;
using MediatR;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetMenuMarkupQueryHandler : IRequestHandler<GetMenuMarkupQuery, InlineReplyMarkup>
    {
        public async Task<InlineReplyMarkup> Handle(GetMenuMarkupQuery request, CancellationToken cancellationToken)
        {
            int previousId = request.CurrentPossition == 0
                         ? request.DishCount - 1
                         : request.CurrentPossition - 1;
            int nextId = request.CurrentPossition + 1 < request.DishCount
                         ? request.CurrentPossition + 1
                         : 0;

            var buttons = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>
                {
                    { "Назад", $"Menu {request.CategoryId} {previousId} Navigation" },
                    { "До меню", "Categories" },
                    { "Купити", $"Buy {request.DishId} 1 Menu" },
                    { "Вперед", $"Menu {request.CategoryId} {nextId} Navigation" },

                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
