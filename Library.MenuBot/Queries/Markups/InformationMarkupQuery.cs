using MediatR;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Queries.Markups
{
    public class InformationMarkupQuery : IRequest<InlineKeyboardMarkup>
    {
    }
}
