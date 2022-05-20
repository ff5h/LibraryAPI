using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class InformationActionCommandHandler : IRequestHandler<InformationActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;

        public InformationActionCommandHandler(ITelegramService telegramService, ISender sender)
        {
            _telegramService = telegramService;
            _sender = sender;
        }

        public async Task<bool> Handle(InformationActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;
            string text = "Номер для замовлення:\nм. Хмельницький, Свободи 13. Контакт: +380999999999";
            var replyMarkup = await _sender.Send(new GetInformationMarkupQuery());
            await _telegramService.RefreshTextMessageAsync(userId, messageId, text, replyMarkup: replyMarkup);
            return true;
        }
    }
}
