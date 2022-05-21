using Library.LibrarianBot.Commands.Updates;
using MediatR;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnUnknownUpdateCommandHandler : IRequestHandler<OnUnknownUpdateCommand, bool>
    {
        public async Task<bool> Handle(OnUnknownUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
