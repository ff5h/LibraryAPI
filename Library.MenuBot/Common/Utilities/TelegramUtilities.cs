using Library.Shared.Implementations;
using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Common.Utilities
{
    public static class TelegramUtilities
    {
        public static InlineReplyMarkup CreateInlineKeyboardButton(Dictionary<string, string> buttonList)
        {
            int columns = 2;
            int rows = (int)Math.Ceiling(buttonList.Count / (double)columns);
            var buttons = new Dictionary<string, string>[rows];
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i] = new Dictionary<string, string>(buttonList.Skip(i * columns).Take(columns));
            }
            var markup = new InlineReplyMarkup(buttons);
            return markup;
        }
    }
}
