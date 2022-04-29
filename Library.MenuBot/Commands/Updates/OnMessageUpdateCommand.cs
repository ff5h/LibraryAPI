using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Updates
{
    public class OnMessageUpdateCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
