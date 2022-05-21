using Library.Shared.Interfaces;
using Telegram.Bot.Types;

namespace Library.MenuBot.Adapters
{
    public class TelegramCallbackQueryAdapter : ICallbackQuery
    {
        private readonly CallbackQuery _callbackQuery;

        public TelegramCallbackQueryAdapter(CallbackQuery callbackQuery)
        {
            _callbackQuery = callbackQuery;
        }

        public string Data => _callbackQuery?.Data;

        public IMessage Message => _callbackQuery.Message != null ? new TelegramMessageAdapter(_callbackQuery.Message) : null;
    }
}
