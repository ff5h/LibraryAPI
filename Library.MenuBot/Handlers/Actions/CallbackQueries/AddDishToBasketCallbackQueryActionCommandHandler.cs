using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Commands.Actions.Messages;
using Library.Repository.Interfaces;
using Library.Repository.Models;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class AddDishToBasketCallbackQueryActionCommandHandler : IRequestHandler<AddDishToBasketCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;
        private readonly IUserService _userService;

        public AddDishToBasketCallbackQueryActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
            _userService = userService;
        }

        public async Task<bool> Handle(AddDishToBasketCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int dishId = int.Parse(splittedCallbackQueryData[1]);
            int count = int.Parse(splittedCallbackQueryData[2]);
            long userId = request.CallbackQuery.Message.UserId;
            var dish = await _ctx.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
            if (dish == null)
                return false;
            var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.UserId == userId && o.DishId == dishId);
            if (order == null)
            {
                order = new Order()
                {
                    UserId = userId,
                    DishId = dish.Id,
                    DishCount = count
                };
                var basket = await _ctx.Baskets.Include(b => b.Orders).FirstOrDefaultAsync(b => b.UserId == userId);
                if (basket == null)
                {
                    basket = new Basket()
                    {
                        UserId = userId,
                        Orders = new List<Order>()
                    };
                    _ctx.Baskets.Add(basket);
                }
                basket.Orders.Add(order);
            }
            else
            {
                order.DishCount += count;
                _ctx.Orders.Update(order);
            }
            await _ctx.SaveChangesAsync();
            await _sender.Send(new MenuActionCommand()
            {
                Message = request.CallbackQuery.Message,
            });
            return true;
        }
    }
}
