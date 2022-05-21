using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Data.Configurations
{
    public class BasketConfiguration : IEntityTypeConfiguration<Basket>
    {
        public void Configure(EntityTypeBuilder<Basket> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .Property(b => b.UserId)
                .IsRequired(true);

            builder
                .HasMany(b => b.Dishes)
                .WithMany(d => d.Baskets);
        }
    }
}
