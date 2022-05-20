using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Commands.Actions.Messages;
using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class ClearBasketCallbackQueryActionCommandHandler : IRequestHandler<ClearBasketCallbackQueryActionCommand, bool>
    {
        private readonly IAppDBContext _ctx;
        private readonly ISender _sender;
        private readonly ITelegramService _telegramService;

        public ClearBasketCallbackQueryActionCommandHandler(IAppDBContext ctx, ISender sender, ITelegramService telegramService)
        {
            _ctx = ctx;
            _sender = sender;
            _telegramService = telegramService;
        }

        public async Task<bool> Handle(ClearBasketCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            var userId = request.CallbackQuery.Message.UserId;
            var orders = await _ctx.Orders.Where(o => o.UserId == userId).ToArrayAsync();
            if (orders == null)
                return false;
            _ctx.Orders.RemoveRange(orders);
            var basket = await _ctx.Baskets.FirstOrDefaultAsync(b => b.UserId == userId);
            if (basket == null)
                return false;
            _ctx.Baskets.Remove(basket);
            await _ctx.SaveChangesAsync();
            await _sender.Send(new StartActionCommand()
            {
                Message = request.CallbackQuery.Message
            });
            return true;
        }
    }
}
