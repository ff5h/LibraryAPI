using Library.Shared.Implementations;
using MediatR;

namespace Library.MenuBot.Queries.Markups.Basic
{
    public class GetBasketMarkupQuery : IRequest<InlineReplyMarkup>
    {
        public int OrderId { get; set; }
    }
}
