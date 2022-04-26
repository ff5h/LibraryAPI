using MediatR;
using Telegram.Bot.Types;

namespace Library.LibrarianBot.Commands.Updates
{
    public class OnCallbackQueryReceivedCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
