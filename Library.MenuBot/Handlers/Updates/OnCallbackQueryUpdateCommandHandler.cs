using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Commands.Updates;
using MediatR;

namespace Library.MenuBot.Handlers.Updates
{
    public class OnCallbackQueryUpdateCommandHandler : IRequestHandler<OnCallbackQueryUpdateCommand, bool> //dev
    {
        private readonly ISender _sender;

        public OnCallbackQueryUpdateCommandHandler(ISender sender)
        {
            _sender = sender;
        }
        public async Task<bool> Handle(OnCallbackQueryUpdateCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            bool result = splittedCallbackQueryData[0] switch
            {
                "Main" => await _sender.Send(new StartActionCommand()
                {
                    Message = request.CallbackQuery.Message,
                }),

                "Confirm" => await _sender.Send(new AddDishToBasketCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Menu" => await _sender.Send(new MenuCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Clear" => await _sender.Send(new ClearBasketCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Basket" => await _sender.Send(new BasketCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Buy" => await _sender.Send(new BuyCallBackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Categories" => await _sender.Send(new MenuActionCommand()
                {
                    Message = request.CallbackQuery.Message,
                }),

                "Remove" => await _sender.Send(new RemoveOrderCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),

                "Finish" => await _sender.Send(new FinishOrderCallbackQueryActionCommand()
                {
                    CallbackQuery = request.CallbackQuery,
                }),  
            };
            return result;
        }
    }
}
