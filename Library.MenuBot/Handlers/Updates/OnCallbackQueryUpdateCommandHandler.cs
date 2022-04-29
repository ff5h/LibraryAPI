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
                _sender.Send(new MenuCallBackQueryReceivedCommand)
            }
            bool result = splittedCallbackQueryData[0] switch
            {
                "Menu" => _sender.Send(new MenuPicker)
            }; //Displayer, Assembler, Demonstrator, Presentor
        }
    }
}
