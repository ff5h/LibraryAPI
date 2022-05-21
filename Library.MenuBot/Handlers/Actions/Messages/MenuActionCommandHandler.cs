using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class MenuActionCommandHandler : IRequestHandler<MenuActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;

        public MenuActionCommandHandler(ITelegramService telegramService, ISender sender)
        {
            _telegramService = telegramService;
            _sender = sender;
        }

        public async Task<bool> Handle(MenuActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;
            string text = "Оберіть категорію:";
            var replyMarkup = await _sender.Send(new GetCategoriesMarkupQuery());
            await _telegramService.RefreshTextMessageAsync(userId, messageId, text, replyMarkup);
            return true;
        }
    }
}
