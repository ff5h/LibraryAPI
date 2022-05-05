using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Queries.Markups
{
    public class GetBuyMarkupQuery : IRequest<IReplyMarkup>
    {
        public int DishId { get; init; }
        public int Count { get; init; }
    }
}
