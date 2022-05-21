namespace Library.Shared.Interfaces
{
    public interface ICallbackQuery
    {
        public string Data { get; }
        public IMessage Message { get; }
    }
}
