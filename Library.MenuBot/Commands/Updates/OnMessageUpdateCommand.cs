using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Updates
{
    public class OnMessageUpdateCommand : IRequest<bool>
    {
        public IMessage Message { get; init; }
    }
}
