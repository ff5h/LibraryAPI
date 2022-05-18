namespace Library.Shared.Interfaces.Services
{
    public interface ITelegramService
    {
        Task<bool> DeleteMessageAsync(long userId, int messageId);
        Task<IMessage> PushMessageAsync(long userId, string text, IMarkup replyMarkup = null);
        Task<bool> RefreshMessageAsync(long userId, int messageId, string text, IMarkup replyMarkup = null);
        void StartReceiving(IUpdateHandler updateHandler, CancellationToken cancellationToken);
    }
}
