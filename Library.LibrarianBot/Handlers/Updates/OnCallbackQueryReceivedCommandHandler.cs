using Library.LibrarianBot.Commands.Updates;
using MediatR;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnCallbackQueryReceivedCommandHandler : IRequestHandler<OnCallbackQueryReceivedCommand, bool>
    {
        public async Task<bool> Handle(OnCallbackQueryReceivedCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
