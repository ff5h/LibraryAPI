using Library.LibrarianBot.Commands.Actions;
using Library.LibrarianBot.Commands.Updates;
using Library.Repository.Interfaces;
using MediatR;
using Telegram.Bot;

namespace Library.LibrarianBot.Handlers.Updates
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
                "Меню" => await _sender.Send(new MenuActionCommand()
                {
                    Message = request.Message
                })
            };
            return result;
        }
    }
}
