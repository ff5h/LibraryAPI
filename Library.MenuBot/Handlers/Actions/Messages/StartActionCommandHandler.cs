using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class StartActionCommandHandler : IRequestHandler<StartActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IUserService _userService;

        public StartActionCommandHandler(ITelegramService telegramService, ISender sender, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _userService = userService;
        }

        public async Task<bool> Handle(StartActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;

            await _telegramService.DeleteMessageAsync(userId, messageId);

            if (await _userService.UserExist(userId))
            {
                messageId = await _userService.GetUserMessageId(userId);
                await _telegramService.DeleteMessageAsync(userId, messageId);
            }

            string text = "Привіт! Я з радістю допоможу тобі обрати та замовити твої улюблені страви!";
            var replyMarkup = await _sender.Send(new GetMainKeyboardMarkupQuery());
            await _telegramService.PushMessageAsync(userId, text, replyMarkup: replyMarkup);
            return true;
        }
    }
}
