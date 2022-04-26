using MediatR;
using Telegram.Bot.Types;

namespace Library.LibrarianBot.Commands.Messages
{
    public class OnMessageReceivedCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
