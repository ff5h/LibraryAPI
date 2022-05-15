using Library.Repository.Interfaces;
using Library.Repository.Models;
using Library.Shared.Interfaces.Services;

namespace LibraryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDBContext _ctx;

        public UserService(IAppDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> AddOrUpdateUser(long userId, int messageId)
        {
            try
            {
                var user = new User()
                {
                    Id = userId,
                    MessageId = messageId
                };
                _ctx.Users.Add(user);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public int GetUserMessageId(long userId)
        {
            throw new NotImplementedException();
        }
    }
}
