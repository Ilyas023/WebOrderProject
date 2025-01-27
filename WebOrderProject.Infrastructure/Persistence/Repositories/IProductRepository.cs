using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrderProject.Domain.Models;

namespace WebOrderProject.Infrastructure.Persistence.Repositories;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(Guid productId);
    Task<List<Product>> GetAllAsync();
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(Guid productId);
}
