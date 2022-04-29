using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Updates
{
    public class OnCallbackQueryUpdateCommand : IRequest<bool>
    {
        public CallbackQuery CallbackQuery { get; init; }
    }
}
