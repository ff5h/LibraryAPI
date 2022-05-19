using Library.MenuBot.Commands.Actions.Messages;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class UnknownActionCommandHandler : IRequestHandler<UnknownActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;

        public UnknownActionCommandHandler(ITelegramService telegramService)
        {
            _telegramService = telegramService;
        }

        public async Task<bool> Handle(UnknownActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;
            string text = "Напишіть \"/start\" щоб почати";
            await _telegramService.RefreshTextMessageAsync(userId, messageId, text);
            return true;
        }
    }
}
