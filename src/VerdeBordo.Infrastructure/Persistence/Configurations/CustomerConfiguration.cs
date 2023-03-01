﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure.Persistence.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(b => b.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);
    }
}
