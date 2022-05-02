using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Commands.Updates;
using MediatR;

namespace Library.MenuBot.Handlers.Updates
{
    public class OnMessageUpdateCommandHandler : IRequestHandler<OnMessageUpdateCommand, bool>
    {
        private readonly ISender _sender;

        public OnMessageUpdateCommandHandler(ISender sender)
        {
            _sender = sender;
        }

        public async Task<bool> Handle(OnMessageUpdateCommand request, CancellationToken cancellationToken)
        {
            bool result = request.Message.Text! switch
            {
                "/start" => await _sender.Send(new StartActionCommand()
                {
                    Message = request.Message
                }),

                "Меню" => await _sender.Send(new MenuActionCommand()
                {
                    Message = request.Message
                }),

                "Кошик" => await _sender.Send(new BasketActionCommand()
                {
                    Message = request.Message
                }),

                "Інформація" => await _sender.Send(new InformationActionCommand()
                {
                    Message = request.Message
                }),

                "Створити карту постійного клієнта" => await _sender.Send(new CreateCardActionCommand()
                {
                    Message = request.Message
                }),

                _ => await _sender.Send(new UnknownActionCommand()
                {
                    Message = request.Message
                }),
            };
            return result;
        }
    }
}
