using Library.Shared.Implementations;
using MediatR;

namespace Library.MenuBot.Queries.Markups
{
    public class GetBuyMarkupQuery : IRequest<InlineReplyMarkup>
    {
        public int DishId { get; init; }
        public int Count { get; init; }
    }
}
