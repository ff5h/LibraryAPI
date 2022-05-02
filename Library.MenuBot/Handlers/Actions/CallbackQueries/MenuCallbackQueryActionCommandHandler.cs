using Library.MenuBot.Commands.Actions.CallbackQueries;
using Library.MenuBot.Queries.Markups;
using MediatR;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Handlers.Actions.CallbackQueries
{
    public class MenuCallbackQueryActionCommandHandler : IRequestHandler<MenuCallbackQueryActionCommand, bool>
    {
        private readonly ITelegramBotClient _botClient;
        private readonly ISender _sender;

        public MenuCallbackQueryActionCommandHandler(ITelegramBotClient botClient, ISender sender)
        {
            _botClient = botClient;
            _sender = sender;
        }

        public async Task<bool> Handle(MenuCallbackQueryActionCommand request, CancellationToken cancellationToken)
        {
            await _botClient.SendPhotoAsync(chatId: request.CallbackQuery.Message.Chat.Id,
                                  caption: "test",
                                  photo: "http://surl.li/bwkax",
                                  replyMarkup: await _sender.Send(new GetCategoryMarkupQuery()));
            return true;
        }
    }
}
