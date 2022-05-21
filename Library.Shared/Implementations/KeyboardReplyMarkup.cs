using Library.Shared.Interfaces;

namespace Library.Shared.Implementations
{
    public class KeyboardReplyMarkup : IMarkup
    {
        public IEnumerable<IEnumerable<string>> Buttons { get; }
        public bool? ResizeKeyboard { get; }

        public KeyboardReplyMarkup(IEnumerable<IEnumerable<string>> buttons, bool? resizeKeyboard = null)
        {
            Buttons = buttons;
            ResizeKeyboard = resizeKeyboard;
        }
    }
}
