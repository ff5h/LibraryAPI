using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Commands.Updates;
using MediatR;

namespace Library.MenuBot.Handlers.Updates
{
    public class OnCallbackQueryUpdateCommandHandler : IRequestHandler<OnCallbackQueryUpdateCommand, bool>
    {
        private readonly ISender _sender;

        public OnCallbackQueryUpdateCommandHandler(ISender sender)
        {
            _sender = sender;
        }
        public Task<bool> Handle(OnCallbackQueryUpdateCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            if (splittedCallbackQueryData[0] == "Menu")
            {
                _sender.Send(new MenuCallbackQueryActionCommand { CategoryId = Convert.ToInt32(splittedCallbackQueryData) });
            }
            
            else if (splittedCallbackQueryData[0] == "Basket")
            {
                _sender.Send(new BasketCallbackQueryActionCommand { CategoryId = Convert.ToInt32(splittedCallbackQueryData) });
            }
        }
    }
}
