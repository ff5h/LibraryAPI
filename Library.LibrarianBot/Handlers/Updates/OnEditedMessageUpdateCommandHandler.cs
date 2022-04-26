using Library.LibrarianBot.Commands.Updates;
using MediatR;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnEditedMessageUpdateCommandHandler : IRequestHandler<OnEditedMessageUpdateCommand, bool>
    {
        public async Task<bool> Handle(OnEditedMessageUpdateCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
