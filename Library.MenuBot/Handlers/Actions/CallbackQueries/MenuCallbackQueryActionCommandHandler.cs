using Library.MenuBot.Commands.Actions.CallbackQueries;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommandHandler : IRequestHandler<MenuCallbackQueryActionCommand, bool>
    {
        public Task<bool> Handle(MenuCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
