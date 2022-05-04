using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Markups
{
    public class GetBuyMarkupQueryHandler : IRequestHandler<GetBuyMarkupQuery, IReplyMarkup>
    {
        public async Task<IReplyMarkup> Handle(GetBuyMarkupQuery request, CancellationToken cancellationToken)
        {
            return null; //доробити
        }
    }
}
