using Library.Shared.Interfaces;
using MediatR;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class BasketCallbackQueryActionCommand : IRequest<bool>
    {
        public ICallbackQuery CallbackQuery { get; set; }
    }
}
