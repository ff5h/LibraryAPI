using Library.MenuBot.Commands.Actions;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions
{
    public class BasketActionCommandHandler : IRequestHandler<BasketActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;

        public BasketActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(BasketActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                         text: "Кошик:");
            return true;
        }
    }
}
