using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class BuyCallBackQueryActionCommand : IRequest<bool>
    {
        public CallbackQuery CallbackQuery { get; init; }
    }
}
