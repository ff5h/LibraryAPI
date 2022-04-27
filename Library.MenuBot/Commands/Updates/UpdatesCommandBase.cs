using MediatR;
using Telegram.Bot.Types;

namespace Library.MenuBot.Commands.Updates
{
    public class UpdatesCommandBase : IRequest<bool>
    {
        public Message Message { get; init; }
    }
}
