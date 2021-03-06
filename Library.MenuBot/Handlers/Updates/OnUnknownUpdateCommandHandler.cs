using Library.MenuBot.Commands.Updates;
using MediatR;

namespace Library.MenuBot.Handlers.Updates
{
    public class OnUnknownUpdateCommandHandler : IRequestHandler<OnUnknownUpdateCommand, bool>
    {
        public async Task<bool> Handle(OnUnknownUpdateCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Get unknown update");
            return true;
        }
    }
}
