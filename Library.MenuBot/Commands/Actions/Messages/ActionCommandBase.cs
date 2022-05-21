using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Actions.Messages
{
    public class ActionCommandBase : IRequest<bool>
    {
        public IMessage Message { get; init; }
    }
}
