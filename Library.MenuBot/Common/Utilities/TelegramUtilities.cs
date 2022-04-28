using Telegram.Bot.Types.ReplyMarkups;

namespace Library.MenuBot.Common.Utilities
{
    public static class TelegramUtilities
    {
        public static InlineKeyboardMarkup CreateInlineKeyboardButton(Dictionary<string, string> buttonList)
        {
            int columns = 2;
            int Rows = (int)Math.Ceiling(buttonList.Count / (double)columns);
            InlineKeyboardButton[][] Buttons = new InlineKeyboardButton[Rows][];
            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i] = buttonList
                    .Skip(i * columns)
                    .Take(columns)
                    .Select(
                        Direction =>
                            InlineKeyboardButton.WithCallbackData(Direction.Value, Direction.Key)
                    )
                    .ToArray();
            }
            return new InlineKeyboardMarkup(Buttons);
        }
    }
}
