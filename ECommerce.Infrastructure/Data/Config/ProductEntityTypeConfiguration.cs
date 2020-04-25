using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Data.Config
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p=>p.Description).IsRequired().HasMaxLength(250);
            builder.Property(p=>p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p=>p.PictureUrl).IsRequired();

            builder.HasOne(b=>b.ProductBrand).WithMany().HasForeignKey(p=>p.ProductBrandId);
            builder.HasOne(t=>t.ProductType).WithMany().HasForeignKey(p=>p.ProductTypeId);
        }
    }
}