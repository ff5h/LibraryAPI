using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Actions.Messages
{
    public class ActionCommandBase : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
