using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommand : IRequest<bool>
    {
        public CallbackQuery CallbackQuery { get; init; }
    }
}
