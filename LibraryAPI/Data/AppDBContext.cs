using Library.Repository.Interfaces;
using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class AppDBContext : DbContext, IAppDBContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DishCategory>().HasKey(d => d.Id);
            builder.Entity<DishCategory>().Property(d => d.Name).IsRequired();

            builder.Entity<DishPhoto>().HasKey(d => d.Id);
            builder.Entity<DishPhoto>().Property(d => d.Name).IsRequired();

            builder.Entity<Dish>().HasKey(d => d.Id);
            builder.Entity<Dish>().Property(d => d.Name).IsRequired();
            builder.Entity<Dish>().Property(d => d.Price).IsRequired();
            builder.Entity<Dish>().Property(d => d.Weight).IsRequired();
            builder.Entity<Dish>().HasOne(d => d.Category).WithMany().IsRequired();
            builder.Entity<Dish>().HasOne(d => d.Photo).WithMany().IsRequired();

            builder.Entity<Basket>().HasKey(b => b.UserId);
            //как быть с листом из дишей?

            builder.Entity<LoyaltyCard>().HasKey(c => c.UserId);
            builder.Entity<LoyaltyCard>().Property(c => c.Balance).IsRequired();
        }

        public DbSet<DishCategory> DishCategories { get; private set; }
        public DbSet<DishPhoto> DishPhotos { get; private set; }
        public DbSet<Dish> Dishes { get; private set; }
        public DbSet<Basket> Baskets { get; private set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; private set; }
    }
}
