using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups;
using Library.Shared.Interfaces.Services;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class MenuActionCommandHandler : IRequestHandler<MenuActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;
        private readonly IUserService _userService;

        public MenuActionCommandHandler(ITelegramBotClient botClient, ISender sender, IUserService userService)
        {
            _botClient = botClient;
            _sender = sender;
            _userService = userService;
        }

        public async Task<bool> Handle(MenuActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: request.Message.MessageId);

            await _botClient.DeleteMessageAsync(chatId: request.Message.Chat.Id,
                                                messageId: await _userService.GetUserMessageId(request.Message.Chat.Id));

            var message = await _botClient.SendTextMessageAsync(chatId: request.Message.Chat.Id,
                                                                text: "Оберіть категорію:",
                                                                replyMarkup: await _sender.Send(new GetCategoriesMarkupQuery()));

            var messageId = message.MessageId;
            await _userService.AddOrUpdateUser(request.Message.Chat.Id, messageId);
            return true;
        }
    }
}
