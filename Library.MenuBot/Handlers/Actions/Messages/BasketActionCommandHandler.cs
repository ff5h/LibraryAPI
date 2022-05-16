using Library.MenuBot.Commands.Actions.Messages;
using Library.Shared.Interfaces.Services;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class BasketActionCommandHandler : IRequestHandler<BasketActionCommand, bool> //add implementation
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IUserService _userService;


        public BasketActionCommandHandler(ITelegramBotClient botClient, IUserService userService)
        {
            _botClient = botClient;
            _userService = userService;
        }

        public async Task<bool> Handle(BasketActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: await _userService.GetUserMessageId(request.Message.Chat.Id));

            var message = await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                                text: "Кошик:");

            var messageId = message.MessageId;
            await _userService.AddOrUpdateUser(request.Message.Chat.Id, messageId);
            return true;
        }
    }
}
