using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.Messages
{
    public class BasketActionCommandHandler : IRequestHandler<BasketActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;

        public BasketActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
        }

        public async Task<bool> Handle(BasketActionCommand request, CancellationToken cancellationToken)
        {
            long userId = request.Message.UserId;
            int messageId = request.Message.Id;
            string text = string.Empty;
            var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.UserId == userId);
            if (order == null)
            {
                text = "У вас пустий кошик";
                var markup = await _sender.Send(new GetInformationMarkupQuery());
                await _telegramService.RefreshTextMessageAsync(userId, messageId, text, replyMarkup: markup);
            }
            var dish = await _ctx.Dishes.FirstOrDefaultAsync(o => o.Id == order.DishId);
            text = $"Кошик\n{dish.Name} {dish.Weight}г.\n💸{dish.Price * order.DishCount}₴";
            var photo = _storage.GetFileInfo(dish.PhotoId);
            var replyMarkup = await _sender.Send(new GetBasketMarkupQuery()
            {
                OrderId = order.Id
            });
            await _telegramService.RefreshTextMessageAsync(userId, messageId, text, photo, replyMarkup);
            return true;
        }
    }
}
