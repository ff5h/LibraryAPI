using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommand : IRequest<bool>
    {
        public ICallbackQuery CallbackQuery { get; init; }
    }
}
