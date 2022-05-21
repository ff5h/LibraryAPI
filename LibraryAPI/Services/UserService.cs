using Library.Repository.Interfaces;
using Library.Repository.Models;
using Library.Shared.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

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
                var newUser = new User()
                {
                    Id = userId,
                    MessageId = messageId
                };

                var currentUser = await _ctx.Users
                    .FirstOrDefaultAsync(u => u.Id == userId);

                if (currentUser == null)
                {
                    _ctx.Users.Add(newUser);
                }
                else
                {
                    currentUser.MessageId = messageId;
                    _ctx.Users.Update(currentUser);
                }
                
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            } 
        }

        public async Task<int> GetUserMessageId(long userId)
        {
            var result = (await _ctx.Users.FirstAsync(u => u.Id == userId)).MessageId;
            return result;
        }

        public async Task<bool> UserExist(long userId)
        {
            var result = await _ctx.Users.AnyAsync(u => u.Id == userId);
            return result;
        }
    }
}
