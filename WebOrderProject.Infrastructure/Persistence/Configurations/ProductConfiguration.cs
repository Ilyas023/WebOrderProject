using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrderProject.Domain.Models;

namespace WebOrderProject.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.ProductId);

        builder.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(p => p.Price)
               .HasPrecision(10, 2)
               .IsRequired();

        builder.Property(p => p.Quantity)
               .IsRequired();

        builder.ToTable("products");
    }
}