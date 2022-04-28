using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Interfaces
{
    public interface IAppDBContext
    {
        public DbSet<DishCategory> DishCategories { get; }
        public DbSet<Dish> Dishes { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
