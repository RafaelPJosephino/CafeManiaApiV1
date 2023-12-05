using CafeManiaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CafeManiaApi.Infra.Data.EntitiesConfiguration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder
                .Property(x => x.Image)
                .IsRequired();

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(x => x.Price)
                .IsRequired();

            builder
                .Property(x => x.Description)
                .HasMaxLength(200);
        }
    }
}