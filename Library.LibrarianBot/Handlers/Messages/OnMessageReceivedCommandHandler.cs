using Library.LibrarianBot.Commands.Messages;
using MediatR;

namespace Library.LibrarianBot.Handlers.Messages
{
    public class OnMessageReceivedCommandHandler : IRequestHandler<OnMessageReceivedCommand, bool>
    {
        public async Task<bool> Handle(OnMessageReceivedCommand request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.Message.Text);
            return true;
        }
    }
}
