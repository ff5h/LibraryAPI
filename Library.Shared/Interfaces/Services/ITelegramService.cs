using Library.Shared.Implementations;

namespace Library.Shared.Interfaces.Services
{
    public interface ITelegramService
    {
        Task<bool> DeleteMessageAsync(long userId, int messageId);
        Task<IMessage> PushMessageAsync(long userId, string text, IFileInfo<Guid> photo = null, IMarkup replyMarkup = null);
        Task<bool> RefreshTextMessageAsync(long userId, int messageId, string text, IFileInfo<Guid> photo = null, IMarkup replyMarkup = null);
        Task<IMessage> EditMessageAsync(long userId, int messageId, string text, IFileInfo<Guid> photo = null, InlineReplyMarkup replyMarkup = null);
        Task<IMessage> EditReplyMarkupAsync(long userId, int messageId, string text, InlineReplyMarkup replyMarkup);

        void StartReceiving(IUpdateHandler updateHandler, CancellationToken cancellationToken);
    }
}
