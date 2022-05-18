using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class BasketActionCommandHandler : IRequestHandler<BasketActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;

        public BasketActionCommandHandler(ITelegramService telegramService, ISender sender)
        {
            _telegramService = telegramService;
            _sender = sender;
        }

        public async Task<bool> Handle(BasketActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;
            string text = "Кошик:";
            var replyMarkup = await _sender.Send(new GetBasketMarkupQuery());
            await _telegramService.RefreshMessageAsync(userId, messageId, text, replyMarkup);
            return true;
        }
    }
}
