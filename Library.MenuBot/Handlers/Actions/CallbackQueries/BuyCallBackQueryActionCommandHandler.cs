using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups;
using Library.Repository.Interfaces;
using Library.Shared.Interfaces.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot;
using Telegram.Bot.Types.InputFiles;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class BuyCallBackQueryActionCommandHandler : IRequestHandler<BuyCallBackQueryActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;
        private readonly IAppDBContext _ctx;
        private readonly IDataStorageService<Guid> _storage;

        public BuyCallBackQueryActionCommandHandler(ITelegramBotClient botClient, ISender sender, IAppDBContext ctx, IDataStorageService<Guid> storage)
        {
            _botClient = botClient;
            _sender = sender;
            _ctx = ctx;
            _storage = storage;
        }

        public async Task<bool> Handle(BuyCallBackQueryActionCommand request, CancellationToken cancellationToken)
        {
            string callbackQueryData = request.CallbackQuery.Data;
            string[] splittedCallbackQueryData = callbackQueryData.Split(' ');
            int dishId = int.Parse(splittedCallbackQueryData[1]);
            var dishes = _ctx.Dishes.Where(d => d.Id == dishId);
            var dish = await dishes.FirstOrDefaultAsync();
            if (dish == null)
                return false;
            int count = int.Parse(splittedCallbackQueryData[2]);
            string caption = $"Ви впевнені, що хочете купити?\n{dish.Name} {dish.Weight}г.\n💸{dish.Price}₴";
            var fileInfo = _storage.GetFileInfo(dish.PhotoId);
            await _botClient.SendPhotoAsync(chatId: request.CallbackQuery.Message.Chat.Id,
                                  caption: caption,
                                  photo: new InputOnlineFile(fileInfo.OpenRead(), fileInfo.Name),
                                  replyMarkup: await _sender.Send(new GetBuyMarkupQuery()
                                  {
                                      DishId = dishId,
                                      Count = count,
                                  }));
            return true;
        }
    }
}
