using Library.LibrarianBot.Commands.Updates;
using MediatR;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnMessageEditedCommandHandler : IRequestHandler<OnMessageEditedCommand, bool>
    {
        public async Task<bool> Handle(OnMessageEditedCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
