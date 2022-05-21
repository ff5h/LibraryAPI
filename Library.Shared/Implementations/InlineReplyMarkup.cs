using Library.Shared.Interfaces;

namespace Library.Shared.Implementations
{
    public class InlineReplyMarkup : IMarkup
    {
        public IEnumerable<Dictionary<string, string>> Buttons { get; }

        public InlineReplyMarkup(IEnumerable<Dictionary<string, string>> buttons)
        {
            Buttons = buttons;
        }
    }
}
