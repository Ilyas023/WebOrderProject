using Microsoft.EntityFrameworkCore;
using WebOrderProject.Domain.Models;
using WebOrderProject.Infrastructure.Persistence.Repositories;

namespace WebOrderProject.Infrastructure.Persistence.Configurations;

public class OrderRepository : IOrderRepository
{
    private readonly WebOrderDbContext _dbContext;

    public OrderRepository(WebOrderDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Order?> GetByIdAsync(Guid orderId)
    {
        return await _dbContext.Orders
            .Include(o => o.OrderProducts) 
            .FirstOrDefaultAsync(o => o.OrderId == orderId);
    }

    public async Task<List<Order>> GetAllAsync()
    {
        return await _dbContext.Orders
            .Include(o => o.OrderProducts)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _dbContext.Orders.AddAsync(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Order order)
    {
        _dbContext.Orders.Update(order);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid orderId)
    {
        var order = await GetByIdAsync(orderId);
        if (order != null)
        {
            order.Status = Order.OrderStatus.Cancelled; 
            await _dbContext.SaveChangesAsync();
        }
    }
}
