using Library.Shared.Interfaces;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Queries.Markups
{
    public class GetBuyMarkupQuery : IRequest<IMarkup>
    {
        public int DishId { get; init; }
        public int Count { get; init; }
    }
}
