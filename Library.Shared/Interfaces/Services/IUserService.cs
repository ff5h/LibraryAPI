namespace Library.Shared.Interfaces.Services
{
    public interface IUserService
    {
        Task<bool> AddOrUpdateUser(long userId, int messageId);
        int GetUserMessageId(long userId);
    }
}
