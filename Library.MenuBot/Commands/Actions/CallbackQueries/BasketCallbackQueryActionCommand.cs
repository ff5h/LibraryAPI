using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class BasketCallbackQueryActionCommand : IRequest<bool>
    {
        public CallbackQuery CallbackQuery { get; set; }
    }
}
