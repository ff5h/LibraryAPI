using MediatR;
using Telegram.Bot.Types;

namespace Library.LibrarianBot.Commands.Actions
{
    public class BaseActionCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
