using Library.LibrarianBot.Commands.Actions;
using Library.LibrarianBot.Commands.Updates;
using Library.Repository.Interfaces;
using MediatR;
using Telegram.Bot;

namespace Library.LibrarianBot.Handlers.Updates
{
    public class OnMessageReceivedCommandHandler : IRequestHandler<OnMessageReceivedCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IAppDBContext _ctx;
        private readonly ISender _sender;

        public OnMessageReceivedCommandHandler(ITelegramBotClient botClient, IAppDBContext ctx ,ISender sender)
        {
            _botClient = botClient;
            _ctx = ctx;
            _sender = sender;
        }

        public async Task<bool> Handle(OnMessageReceivedCommand request, CancellationToken cancellationToken)
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
