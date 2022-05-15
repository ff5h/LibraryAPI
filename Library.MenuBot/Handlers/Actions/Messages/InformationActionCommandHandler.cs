using Library.MenuBot.Commands.Actions.Messages;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class InformationActionCommandHandler : IRequestHandler<InformationActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;

        public InformationActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(InformationActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            string text = "Номер для замовлення:\nм. Хмельницький, Свободи 13. Контакт: +380999999999";
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                  text: text);
            return true;
        }
    }
}
