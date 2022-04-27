using Library.MenuBot.Commands.Updates;
using MediatR;

namespace Library.MenuBot.Handlers.Updates
{
    public class OnCallbackQueryUpdateCommandHandler : IRequestHandler<OnCallbackQueryUpdateCommand, bool>
    {
        public async Task<bool> Handle(OnCallbackQueryUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
