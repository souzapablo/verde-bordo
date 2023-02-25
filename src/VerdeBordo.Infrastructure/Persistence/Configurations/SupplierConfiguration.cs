using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure.Persistence.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);

        builder.HasMany(s => s.Products)
            .WithOne(s => s.Supplier)
            .HasForeignKey(s => s.SupplierId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
