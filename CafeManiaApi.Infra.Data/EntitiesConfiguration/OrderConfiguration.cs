using CafeManiaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeManiaApi.Infra.Data.EntitiesConfiguration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.UserId)
                .IsRequired();

            builder
                .Property(x => x.DateOrder)
                .IsRequired();

            builder
                .Property(x => x.Finished)
                .IsRequired();

            builder
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasMany(x => x.Products)
                .WithOne(u => u.Order)
                .HasForeignKey(u => u.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}