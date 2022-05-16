using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups;
using Library.Shared.Interfaces.Services;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class StartActionCommandHandler : IRequestHandler<StartActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;
        private readonly IUserService _userService;

        public StartActionCommandHandler(ITelegramBotClient botClient, ISender sender, IUserService userService)
        {
            _botClient = botClient;
            _sender = sender;
            _userService = userService;
        }

        public async Task<bool> Handle(StartActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);
            
            try
            {
                await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: await _userService.GetUserMessageId(request.Message.Chat.Id));
            }
            catch { }

            var message = await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                                text: "Привіт! Я з радістю допоможу тобі обрати та замовити твої улюблені страви!",
                                                                replyMarkup: await _sender.Send(new GetMainKeyboardMarkupQuery()));

            var messageId = message.MessageId;
            await _userService.AddOrUpdateUser(request.Message.Chat.Id, messageId);
            return true;
        }
    }
}
