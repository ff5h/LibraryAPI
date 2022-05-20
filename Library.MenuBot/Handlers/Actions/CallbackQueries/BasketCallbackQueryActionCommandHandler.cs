using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class BasketCallbackQueryActionCommandHandler : IRequestHandler<BasketCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;
        private readonly IUserService _userService;

        public BasketCallbackQueryActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
            _userService = userService;
        }

        public async Task<bool> Handle(BasketCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            long userId = int.Parse(splittedCallbackQueryData[1]);
            int orderId = int.Parse(splittedCallbackQueryData[2]);
            string? source = splittedCallbackQueryData[3];
            var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            if (order == null)
                return false;
            int dishId = order.DishId;
            var dish = await _ctx.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
            int messageId = await _userService.GetUserMessageId(userId);
            string text = $"{dish.Name} {dish.Weight}г.\n💸{dish.Price * order.DishCount}₴";
            var photo = _storage.GetFileInfo(dish.PhotoId);
            var replyMarkup = await _sender.Send(new GetBasketMarkupQuery()
            {
                OrderId = order.Id
            });
            if (source == "Navigation") //From GetBasketMarkupQueryHandler
            {
                messageId = await _userService.GetUserMessageId(userId);
                await _telegramService.EditMessageAsync(userId, messageId, text, photo, replyMarkup);
            }
            return true;
        }
    }
}
