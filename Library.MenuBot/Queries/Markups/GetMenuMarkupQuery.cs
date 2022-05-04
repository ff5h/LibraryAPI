using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Queries.Markups
{
    public class GetMenuMarkupQuery : IRequest<IReplyMarkup>
    {
        public int CategoryId { get; init; }
        public int CurrentPossition { get; init; }
        public int DishCount { get; init; }
        public int DishId { get; init; }
    }
}
