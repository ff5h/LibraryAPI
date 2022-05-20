using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class RemoveOrderCallbackQueryActionCommandHandler : IRequestHandler<RemoveOrderCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;
        private readonly IUserService _userService;

        public RemoveOrderCallbackQueryActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
            _userService = userService;
        }

        public async Task<bool> Handle(RemoveOrderCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int orderId = int.Parse(splittedCallbackQueryData[1]);
            var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            var dish = await _ctx.Dishes.FirstOrDefaultAsync(o => o.Id == order.DishId);
            _ctx.Orders.Remove(order);
            await _ctx.SaveChangesAsync();
            return true;
        }
    }
}
