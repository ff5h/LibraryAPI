using Library.LibrarianBot.Commands.Actions;
using MediatR;
using Telegram.Bot;

namespace Library.LibrarianBot.Handlers.Actions
{
    public class MenuActionCommandHandler : IRequestHandler<MenuActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;

        public MenuActionCommandHandler(ITelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        public async Task<bool> Handle(MenuActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                         text: "Оберіть категорію:");
            return true;
        }
    }
}
