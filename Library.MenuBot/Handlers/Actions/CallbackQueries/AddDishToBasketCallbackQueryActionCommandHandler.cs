using Library.MenuBot.Commands.Actions.CallbackQueries;
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
            //string callbackQueryData = request.CallbackQuery.Data;
            //string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            //int dishId = int.Parse(splittedCallbackQueryData[1]);
            //int count = int.Parse(splittedCallbackQueryData[2]);

            //long userId = request.CallbackQuery.Message.UserId;
            //var basket = await _ctx.Baskets.Include(b => b.Dishes).FirstOrDefaultAsync(b => b.UserId == userId);
            //if (basket == null)
            //{
            //    basket = new Basket()
            //    {
            //        UserId = userId,
            //        Dishes = new List<Dish>()
            //    };
            //    _ctx.Baskets.Add(basket);
            //}
            //var dish = await _ctx.Dishes.FirstOrDefaultAsync(d => d.Id == dishId);
            //if (dish == null)
            //   return false;
            //for (int i = 0; i <= count; i++)
            //{
            //    basket.Dishes.Add(dish);
            //}

            //await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
