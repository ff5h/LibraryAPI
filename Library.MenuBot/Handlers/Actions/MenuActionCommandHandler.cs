using Library.MenuBot.Commands.Actions;
using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions
{
    public class MenuActionCommandHandler : IRequestHandler<MenuActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;

        public MenuActionCommandHandler(ITelegramBotClient botClient, ISender sender)
        {
            _botClient = botClient;
            _sender = sender;
        }

        public async Task<bool> Handle(MenuActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                         text: "Оберіть категорію:",
                                                         replyMarkup: await _sender.Send(new GetMenuMarkupQuery()));
            return true;
        }
    }
}
