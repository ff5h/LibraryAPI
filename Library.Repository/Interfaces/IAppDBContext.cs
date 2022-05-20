using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<DishCategory> DishCategories { get; }
        public DbSet<Attachment> Attachments { get; }
        public DbSet<Dish> Dishes { get; }
        public DbSet<Basket> Baskets { get; }
        public DbSet<User> Users { get; }
        public DbSet<Order> Orders { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
