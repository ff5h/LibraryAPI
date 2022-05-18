using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using LiteDB;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommandHandler : IRequestHandler<MenuCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;

        public MenuCallbackQueryActionCommandHandler(ITelegramBotClient botClient, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage)
        {
            _botClient = botClient;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
        }

        public async Task<bool> Handle(MenuCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int categoryId = int.Parse(splittedCallbackQueryData[1]);
            int currentPossition = int.Parse(splittedCallbackQueryData[2]);
            var dishes = _ctx.Dishes.Where(d => d.CategoryId == categoryId);
            var dish = await dishes.Skip(currentPossition).FirstOrDefaultAsync();
            if (dish == null)
                return false;
            string caption = $"{dish.Name} {dish.Weight}г.\n💸{dish.Price}₴";
            var fileInfo = _storage.GetFileInfo(dish.PhotoId);
            await _botClient.SendPhotoAsync(chatId: request.CallbackQuery.Message.UserId,
                                  caption: caption,
                                  photo: new InputOnlineFile(fileInfo.OpenRead(), fileInfo.Name),
                                  replyMarkup: await _sender.Send(new GetMenuMarkupQuery()
                                  {
                                      CurrentPossition = currentPossition,
                                      CategoryId = categoryId,
                                      DishCount = await dishes.CountAsync(),
                                      DishId = dish.Id,
                                  }));
            return true;
        }
    }
}
