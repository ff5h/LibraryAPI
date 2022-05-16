using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups;
using Library.Shared.Interfaces.Services;
using MediatR;
using Telegram.Bot;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class InformationActionCommandHandler : IRequestHandler<InformationActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;
        private readonly IUserService _userService;

        public InformationActionCommandHandler(ITelegramBotClient botClient, ISender sender, IUserService userService)
        {
            _botClient = botClient;
            _sender = sender;
            _userService = userService;
        }

        public async Task<bool> Handle(InformationActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: await _userService.GetUserMessageId(request.Message.Chat.Id));

            string text = "Номер для замовлення:\nм. Хмельницький, Свободи 13. Контакт: +380999999999";
            var message = await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                                text: text,
                                                                replyMarkup: await _sender.Send(new InformationMarkupQuery()));

            var messageId = message.MessageId;
            await _userService.AddOrUpdateUser(request.Message.Chat.Id, messageId);
            return true;
        }
    }
}
