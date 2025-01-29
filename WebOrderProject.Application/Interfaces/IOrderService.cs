using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebOrderProject.Application.DTOs;
using static WebOrderProject.Domain.Models.Order;

namespace WebOrderProject.Application.Interfaces;

public interface IOrderService
{
    Task<OrderDto?> GetOrderByIdAsync(Guid orderId);
    Task<List<OrderDto>> GetAllOrdersAsync();
    Task<Guid> CreateOrderAsync(CutOrderDto orderDto);
    Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status);
    Task UpdateOrderAsync(Guid orderId, CutOrderDto orderDto);
    Task DeleteOrderAsync(Guid orderId);
}
