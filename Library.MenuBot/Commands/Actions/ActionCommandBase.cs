using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Actions
{
    public class ActionCommandBase : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
