using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<DishCategory> DishCategories { get; }
        public DbSet<DishPhoto> DishPhotos { get; }
        public DbSet<Dish> Dishes { get; }
        public DbSet<Basket> Baskets { get; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
