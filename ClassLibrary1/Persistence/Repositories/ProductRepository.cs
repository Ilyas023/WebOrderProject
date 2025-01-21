using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrderProject.Domain.Models;
using WebOrderProject.Infrastructure.Persistence.Repositories;

namespace WebOrderProject.Infrastructure.Persistence.Configurations;

public class ProductRepository : IProductRepository
{
    private readonly WebOrderDbContext _dbContext;

    public ProductRepository(WebOrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product?> GetByIdAsync(Guid productId)
    {
        return await _dbContext.Products
            .Include(p => p.OrderProducts)
            .ThenInclude(op => op.Order)
            .FirstOrDefaultAsync(p => p.ProductId == productId);
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products
            .Include(p => p.OrderProducts)
            .ThenInclude(op => op.Order)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid productId)
    {
        var product = await GetByIdAsync(productId);
        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }
}