using Library.Shared.Enums;
using Library.Shared.Interfaces;
using Telegram.Bot.Types;

namespace Library.MenuBot.Adapters
{
    public class TelegramUpdateAdapter : IUpdate
    {
        private readonly Update _update;

        public TelegramUpdateAdapter(Update update)
        {
            _update = update;
        }

        public ICallbackQuery CallbackQuery => _update.CallbackQuery != null ? new TelegramCallbackQueryAdapter(_update.CallbackQuery) : null;

        public IMessage Message => _update.Message != null ? new TelegramMessageAdapter(_update.Message) : null;

        public UpdateType Type => (UpdateType)_update.Type;
    }
}
