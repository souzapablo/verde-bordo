﻿using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VerdeBordo.Core.Entities;

namespace VerdeBordo.Infrastructure;

public class VerdeBordoDbContext : DbContext
{
    public VerdeBordoDbContext(DbContextOptions<VerdeBordoDbContext> options) : base(options)
    {

    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Embroidery> Embroideries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
