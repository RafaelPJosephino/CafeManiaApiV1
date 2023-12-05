using CafeManiaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeManiaApi.Infra.Data.EntitiesConfiguration
{
    internal class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.ProductId)
                .IsRequired();

            builder
                .Property(x => x.OrderId)
                .IsRequired();

            builder
                .HasOne(po => po.Product)
                .WithMany()
                .HasForeignKey(po => po.ProductId);

            builder
                .HasOne(x => x.Order)
                .WithMany(o => o.Products)
                .HasForeignKey(x => x.OrderId);
        }
    }
}