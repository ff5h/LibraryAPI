using Library.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Data.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.HasKey(d => d.Id);

            builder
                .Property(d => d.Name)
                .IsRequired(true);

            builder
                .Property(d => d.Price)
                .IsRequired(true);

            builder
                .Property(d => d.Weight)
                .IsRequired(true);

            builder
                .HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(c => c.CategoryId)
                .IsRequired(true);

            builder
                .HasOne(d => d.Photo)
                .WithMany()
                .HasForeignKey(c => c.PhotoId)
                .IsRequired(true);
        }
    }
}
