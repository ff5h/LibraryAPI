using Library.MenuBot.Commands.Actions.Messages;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class UnknownActionCommandHandler : IRequestHandler<UnknownActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;

        public UnknownActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(UnknownActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                         text: "Напишіть \"/start\" щоб почати");
            return true;
        }
    }
}
