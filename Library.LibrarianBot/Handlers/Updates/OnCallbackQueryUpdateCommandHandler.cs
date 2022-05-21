using Library.LibrarianBot.Commands.Updates;
using MediatR;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnCallbackQueryUpdateCommandHandler : IRequestHandler<OnCallbackQueryUpdateCommand, bool>
    {
        public async Task<bool> Handle(OnCallbackQueryUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
