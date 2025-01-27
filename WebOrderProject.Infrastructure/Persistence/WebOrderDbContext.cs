using Microsoft.EntityFrameworkCore;
using System;
using WebOrderProject.Domain.Models;
using WebOrderProject.Infrastructure.Persistence.Configurations;

namespace WebOrderProject.Infrastructure.Persistence;

public class WebOrderDbContext : DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<OrderProduct> OrderProducts { get; set; }

    public WebOrderDbContext(DbContextOptions<WebOrderDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderProductConfiguration());
    }

}
