using Library.MenuBot.Commands.Actions.CallbackQueries;
using MediatR;
using Telegram.Bot;

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
            var buttons = new[]
                    {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData("Назад", "Previous"),
                            InlineKeyboardButton.WithCallbackData("До меню", "Menu"),
                            InlineKeyboardButton.WithCallbackData("Кошик", "Basket"),
                            InlineKeyboardButton.WithCallbackData("Вперед", "Next"),
                        },
                    };
            InlineKeyboardMarkup inlineKeyboard = new(buttons);
            await botClient.SendPhotoAsync(chatId: update.Message.Chat.Id,
                                  caption: "test",
                                  photo: "http://surl.li/bwkax",
                                  replyMarkup: inlineKeyboard);
        }
    }
}
