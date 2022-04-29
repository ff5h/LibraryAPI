using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class StartActionCommandHandler : IRequestHandler<StartActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;

        public StartActionCommandHandler(ITelegramBotClient botClient, ISender sender)
        {
            _botClient = botClient;
            _sender = sender;
        }

        public async Task<bool> Handle(StartActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                         text: "Привіт! Я з радістю допоможу тобі обрати та замовити твої улюблені страви!",
                                                         replyMarkup: await _sender.Send(new GetMainKeyboardMarkupQuery()));
            return true;
        }
    }
}
