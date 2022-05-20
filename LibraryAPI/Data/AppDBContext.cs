using Library.Repository.Interfaces;
using Library.Repository.Models;
using LibraryAPI.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DishConfiguration());
            builder.ApplyConfiguration(new DishCategoryConfiguration());
            builder.ApplyConfiguration(new AttachmentConfiguration());
            builder.ApplyConfiguration(new BasketConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
        }

        public DbSet<DishCategory> DishCategories { get; private set; }
        public DbSet<Attachment> Attachments { get; private set; }
        public DbSet<Dish> Dishes { get; private set; }
        public DbSet<Basket> Baskets { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Order> Orders { get; private set; }

    }
}
