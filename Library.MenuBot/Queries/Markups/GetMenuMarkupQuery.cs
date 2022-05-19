using Library.Shared.Implementations;
using MediatR;

namespace Library.MenuBot.Queries.Markups
{
    public class GetMenuMarkupQuery : IRequest<InlineReplyMarkup>
    {
        public int CategoryId { get; init; }
        public int CurrentPossition { get; init; }
        public int DishCount { get; init; }
        public int DishId { get; init; }
    }
}
