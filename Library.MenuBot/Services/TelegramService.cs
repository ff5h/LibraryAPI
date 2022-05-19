using Library.Shared.Interfaces;
using Library.Shared.Implementations;
using Library.Shared.Interfaces.Services;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Library.MenuBot.Adapters;
using Library.MenuBot.Configurations;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.InputFiles;
using Telegram.Bot.Types;

namespace Library.MenuBot.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly ITelegramBotClient _botClient;
        private readonly IUserService _userService;

        public TelegramService(IUserService userService, TokenConfiguration token)
        {
            _botClient = new TelegramBotClient(token.Token);
            _userService = userService;
        }

        public async Task<IMessage> PushMessageAsync(long userId, string text, IFileInfo<Guid> photo = null, IMarkup replyMarkup = null)
        {
            IReplyMarkup? markup = null;
            if (replyMarkup is KeyboardReplyMarkup keyboardMarkup)
            {
                var buttons = keyboardMarkup.Buttons.Select(x => x.Select(x => new KeyboardButton(x)));
                markup = new ReplyKeyboardMarkup(buttons)
                {
                    ResizeKeyboard = keyboardMarkup.ResizeKeyboard
                };
            }

            if (replyMarkup is InlineReplyMarkup inlineMarkup)
            {
                var buttons = inlineMarkup.Buttons.Select(x => x.Select(x => InlineKeyboardButton.WithCallbackData(x.Key, x.Value)));
                markup = new InlineKeyboardMarkup(buttons);
            }

            Message? message = null;
            if (photo == null)
            {
                message = await _botClient.SendTextMessageAsync(userId, text, replyMarkup: markup);
            }
            else
            {
                var media = new InputOnlineFile(photo.OpenRead(), photo.Name);
                message = await _botClient.SendPhotoAsync(userId, photo: media, caption: text, replyMarkup: markup);
            }
            
            await _userService.AddOrUpdateUser(userId, message.MessageId);
            var result = new TelegramMessageAdapter(message);
            return result;
        }

        public async Task<bool> DeleteMessageAsync(long userId, int messageId)
        {
            try
            {
                await _botClient.DeleteMessageAsync(userId, messageId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> RefreshTextMessageAsync(long userId, int messageId, string text, IMarkup replyMarkup = null)
        {
            try
            {
                await DeleteMessageAsync(userId, messageId);
                await DeleteMessageAsync(userId, await _userService.GetUserMessageId(userId));
                await PushMessageAsync(userId, text, replyMarkup: replyMarkup);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void StartReceiving(Shared.Interfaces.IUpdateHandler updateHandler, CancellationToken cancellationToken)
        {
            var receiverOptions = new ReceiverOptions() { AllowedUpdates = { } };
            _botClient.StartReceiving(
                updateHandler: (_, update, cancel) => updateHandler.HandleUpdateAsync(new TelegramUpdateAdapter(update), cancel),
                errorHandler: (_, exception, cancel) => updateHandler.HandleErrorAsync(exception, cancel),
                receiverOptions: receiverOptions,
                cancellationToken: cancellationToken);
        }

        public async Task<IMessage> EditMessageAsync(long userId, int messageId, string text, IFileInfo<Guid> photo = null, InlineReplyMarkup replyMarkup = null)
        {
            var media = new InputMediaPhoto(new InputMedia(photo.OpenRead(), photo.Name));
            var buttons = replyMarkup.Buttons.Select(x => x.Select(x => InlineKeyboardButton.WithCallbackData(x.Key, x.Value)));
            var markup = new InlineKeyboardMarkup(buttons);
            await _botClient.EditMessageMediaAsync(chatId: userId, messageId: messageId, media: media, replyMarkup: markup);
            var message = await _botClient.EditMessageCaptionAsync(chatId: userId, messageId: messageId, caption: text, replyMarkup: markup);
            var result = new TelegramMessageAdapter(message);
            return result;
        }

        public async Task<IMessage> EditReplyMarkupAsync(long userId, int messageId, string text, InlineReplyMarkup replyMarkup)
        {
            var buttons = replyMarkup.Buttons.Select(x => x.Select(x => InlineKeyboardButton.WithCallbackData(x.Key, x.Value)));
            var markup = new InlineKeyboardMarkup(buttons);
            var message = await _botClient.EditMessageReplyMarkupAsync(chatId: userId, messageId: messageId, replyMarkup: markup);
            var result = new TelegramMessageAdapter(message);
            return result;
        }
    }
}