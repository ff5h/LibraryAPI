using Library.Shared.Enums;

namespace Library.Shared.Interfaces
{
    public interface IUpdate
    {
        public ICallbackQuery CallbackQuery { get; }
        public IMessage Message { get; }
        public UpdateType Type { get; }
    }
}
