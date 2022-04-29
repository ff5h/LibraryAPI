using Library.MenuBot.Commands.Actions.CallbackQueries;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class BasketCallbackQueryActionCommandHandler : IRequestHandler<BasketCallbackQueryActionCommand, bool>
    {
        public Task<bool> Handle(BasketCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
