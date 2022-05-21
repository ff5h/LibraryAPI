using Library.Shared.Interfaces;
using Telegram.Bot.Types;

namespace Library.MenuBot.Adapters
{
    public class TelegramMessageAdapter : IMessage
    {
        private readonly Message _message;

        public TelegramMessageAdapter(Message message)
        {
            _message = message;
        }

        public int Id => _message != null ? _message.MessageId : -1;

        public long UserId => _message != null && _message.Chat != null ? _message.Chat.Id : -1;

        public string? Text => _message?.Text;
    }
}
