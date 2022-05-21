using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Updates
{
    public class OnUnknownUpdateCommand : IRequest<bool>
    {
        public IUpdate Update { get; init; }
    }
}
