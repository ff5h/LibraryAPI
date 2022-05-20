using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class FinishOrderCallbackQueryActionCommandHandler : IRequestHandler<FinishOrderCallbackQueryActionCommand, bool>
    {
        private readonly IAppDBContext _ctx;
        private readonly ISender _sender;
        private readonly ITelegramService _telegramService;
        private readonly IUserService _userService;

        public FinishOrderCallbackQueryActionCommandHandler(IAppDBContext ctx, ISender sender, ITelegramService telegramService, IUserService userService)
        {
            _ctx = ctx;
            _sender = sender;
            _telegramService = telegramService;
            _userService = userService;
        }

        public async Task<bool> Handle(FinishOrderCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.CallbackQuery.Message.UserId;
            int messageId = await _userService.GetUserMessageId(userId);
            string text = "Дякую за замовлення, до вас підійдуть";
            var replyMarkup = await _sender.Send(new GetInformationMarkupQuery());
            await _telegramService.RefreshTextMessageAsync(userId, messageId, text, replyMarkup: replyMarkup);
            return true;
        }
    }
}
