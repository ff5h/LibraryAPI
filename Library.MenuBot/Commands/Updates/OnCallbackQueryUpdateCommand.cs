using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Updates
{
    public class OnCallbackQueryUpdateCommand : IRequest<bool>
    {
        public ICallbackQuery CallbackQuery { get; init; }
    }
}
