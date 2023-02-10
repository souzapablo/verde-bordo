using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure.Persistence.Configurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Product)
            .WithOne()
            .HasForeignKey<Purchase>(p => p.ProductId);

        builder.Property(p => p.AmountPurchased)
            .HasPrecision(3, 2);

        builder.Property(p => p.Shipment)
            .HasPrecision(3, 2);
    }
}
