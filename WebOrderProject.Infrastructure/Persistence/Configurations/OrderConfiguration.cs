using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WebOrderProject.Domain.Models;
using static WebOrderProject.Domain.Models.Order;

namespace WebOrderProject.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.OrderId);

        builder.Property(o => o.CustomerName)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(o => o.Status)
               .HasConversion<string>() 
               .IsRequired();

        builder.Property(o => o.TotalPrice)
               .HasPrecision(10, 2)
               .IsRequired();

        builder.Property(o => o.CreatedAt)
               .HasDefaultValueSql("NOW()")
               .IsRequired();

        builder.ToTable("Order");
    }
}


