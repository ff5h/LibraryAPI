using Library.MenuBot.Queries.Markups.Basic;
using Library.Repository.Interfaces;
using Library.Shared.Implementations;
using Library.Shared.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Markups.Basic
{
    public class GetBasketMarkupQueryHandler : IRequestHandler<GetBasketMarkupQuery, InlineReplyMarkup>
    {
        private readonly IAppDBContext _ctx;

        public GetBasketMarkupQueryHandler(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<InlineReplyMarkup> Handle(GetBasketMarkupQuery request, CancellationToken cancellationToken)
        {
            int orderId = request.OrderId;
            var order = await _ctx.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
            int dishId = order.DishId;
            int dishCount = order.DishCount;
            long userId = order.UserId;
            var userOrders = await _ctx.Orders.Where(o => o.UserId == userId).ToArrayAsync();
            int currentId = Array.IndexOf(userOrders, order);
            int previousOrderId = currentId == 0
                         ? userOrders.Count() - 1
                         : currentId - 1;
            int nextOrderId = currentId + 1 < userOrders.Count()
                         ? currentId + 1
                         : 0;

            var buttons = new Dictionary<string, string>[]
            {
                new Dictionary<string, string>
                {
                    { "Купити", "Finish" },
                },

                new Dictionary<string, string>
                {
                    { "Очистити", "Clear" },
                    { "Видалити", $"Remove {orderId}" },
                },

                new Dictionary<string, string>
                {
                    { "<-", $"Basket {userId} {userOrders[previousOrderId].Id} Navigation" },
                    { $"Шт. {dishCount}", "#" },
                    { "->", $"Basket {userId} {userOrders[nextOrderId].Id} Navigation" },
                },

                new Dictionary<string, string>
                {
                    { "Головна", "Main" },
                },
            };
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
