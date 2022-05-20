using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.UserId)
                .IsRequired(true);

            builder
                .HasOne(d => d.Dish)
                .WithMany()
                .HasForeignKey(c => c.DishId)
                .IsRequired(true);

            builder
                .Property(d => d.DishCount)
                .IsRequired(true);
        }
    }
}
