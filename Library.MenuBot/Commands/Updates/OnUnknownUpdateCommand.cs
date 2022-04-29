using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Updates
{
    public class OnUnknownUpdateCommand : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
