using Library.MenuBot.Commands.Actions.Messages;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class BasketActionCommandHandler : IRequestHandler<BasketActionCommand, bool> //add implementation
    {
        private readonly ITelegramBotClient _botClient;

        public BasketActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(BasketActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                  text: "Кошик:");
            return true;
        }
    }
}
