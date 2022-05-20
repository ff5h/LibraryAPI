using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using LiteDB;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommandHandler : IRequestHandler<MenuCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramService _telegramService;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;
        private readonly IUserService _userService;

        public MenuCallbackQueryActionCommandHandler(ITelegramService telegramService, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage, IUserService userService)
        {
            _telegramService = telegramService;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
            _userService = userService;
        }

        public async Task<bool> Handle(MenuCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int categoryId = int.Parse(splittedCallbackQueryData[1]);
            int currentPossition = int.Parse(splittedCallbackQueryData[2]);
            string? source = splittedCallbackQueryData[3];
            var dishes = _ctx.Dishes.Where(d => d.CategoryId == categoryId);
            var dish = await dishes.Skip(currentPossition).FirstOrDefaultAsync();
            if (dish == null)
                return false;

            long userId = request.CallbackQuery.Message.UserId;
            int messageId = await _userService.GetUserMessageId(userId);
            string text = $"{dish.Name} {dish.Weight}г.\n💸{dish.Price}₴";
            var photo = _storage.GetFileInfo(dish.PhotoId);
            var replyMarkup = await _sender.Send(new GetMenuMarkupQuery()
            {
                CurrentPossition = currentPossition,
                CategoryId = categoryId,
                DishCount = await dishes.CountAsync(),
                DishId = dish.Id,
            });

            if (source == "CategoryMenu") //From GetCategoriesMarkupQueryHandler
            {
                await _telegramService.DeleteMessageAsync(userId, messageId);
                await _telegramService.PushMessageAsync(userId, text, photo, replyMarkup: replyMarkup);
            }

            if (source == "Navigation") //From GetMenuMarkupQueryHandler
            {
                messageId = await _userService.GetUserMessageId(userId);
                await _telegramService.EditMessageAsync(userId, messageId, text, photo, replyMarkup);
            }

            if (source == "Cancel") //From GetBuyMarkupQueryHandler
            {
                messageId = await _userService.GetUserMessageId(userId);
                await _telegramService.EditMessageAsync(userId, messageId, text, photo, replyMarkup);
            }
            return true;
        }
    }
}
