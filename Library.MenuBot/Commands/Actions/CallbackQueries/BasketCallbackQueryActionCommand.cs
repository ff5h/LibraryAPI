using MediatR;

namespace Library.MenuBot.Commands.Actions.CallbackQueries
{
    public class BasketCallbackQueryActionCommand : IRequest<bool>
    {
        public int CategoryId { get; set; }
    }
}
