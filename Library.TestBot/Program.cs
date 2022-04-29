using System.Text;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Bot
{
    public static class Program
    {
        private static TelegramBotClient? Bot;

        public static async Task Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Bot = new TelegramBotClient("5396618963:AAGUns52qfeqgJ-5ArprOmixk2r9PD42qJU");
            User me = await Bot.GetMeAsync();
            Console.Title = me.Username ?? "My awesome Bot";

            using var cts = new CancellationTokenSource();

            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new() { AllowedUpdates = { } };
            Bot.StartReceiving(HandleUpdateAsync,
                               HandleErrorAsync,
                               receiverOptions,
                               cts.Token);

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }

        public static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message)
            {
                if (update.Message.Text == "Меню")
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

            if (update.Type == UpdateType.CallbackQuery)
            {
                
            }
        }
    }
}