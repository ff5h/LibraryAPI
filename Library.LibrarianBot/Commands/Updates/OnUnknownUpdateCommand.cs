using MediatR;
using Telegram.Bot.Types;

namespace Library.LibrarianBot.Commands.Updates
{
    public class OnUnknownUpdateCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
