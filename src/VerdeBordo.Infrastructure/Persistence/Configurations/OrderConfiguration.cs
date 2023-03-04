using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasMany(o => o.Embroideries)
            .WithOne(e => e.Order)
            .HasForeignKey(e => e.OrderId);

        builder.HasMany(o => o.Payments)
            .WithOne(p => p.Order)
            .HasForeignKey(p => p.OrderId);  

        builder.Property(o => o.Shipment)
            .HasPrecision(14, 8);    
    }
}