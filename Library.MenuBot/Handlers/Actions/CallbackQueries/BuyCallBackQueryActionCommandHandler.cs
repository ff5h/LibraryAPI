using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class BuyCallBackQueryActionCommandHandler : IRequestHandler<BuyCallBackQueryActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;
        private readonly IUserService _userService;

        public BuyCallBackQueryActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
            _userService = userService;
        }

        public async Task<bool> Handle(BuyCallBackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int dishId = int.Parse(splittedCallbackQueryData[1]);
            int count = int.Parse(splittedCallbackQueryData[2]);
            string? source = splittedCallbackQueryData[3];
            var dishes = _ctx.Dishes.Where(d => d.Id == dishId);
            var dish = await dishes.FirstOrDefaultAsync();
            if (dish == null)
                return false;

            long userId = request.CallbackQuery.Message.UserId;
            int messageId = await _userService.GetUserMessageId(userId);
            string text = $"Ви впевнені, що хочете купити?\n{dish.Name} {dish.Weight}г.\n💸{dish.Price}₴";
            var photo = _storage.GetFileInfo(dish.PhotoId);
            var replyMarkup = await _sender.Send(new GetBuyMarkupQuery()
            {
                DishId = dishId,
                Count = count,
            });

            if (source == "Menu") //From GetCategoriesMarkupQueryHandler
            {
                await _telegramService.EditMessageAsync(userId, messageId, text, photo, replyMarkup);
            }

            if (source == "Navigation") //From GetMenuMarkupQueryHandler
            {
                await _telegramService.EditReplyMarkupAsync(userId, messageId, text, replyMarkup);
            }
            return true;
        }
    }
}
