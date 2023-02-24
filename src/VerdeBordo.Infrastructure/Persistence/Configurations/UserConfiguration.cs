using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.HasMany(u => u.Customers)
            .WithOne(c => c.User)
            .HasForeignKey(c => c.UserId)           
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Suppliers)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId)            
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.Purchases)
            .WithOne(p => p.User)
            .HasForeignKey(p => p.UserId)            
            .OnDelete(DeleteBehavior.Restrict);
    }
}