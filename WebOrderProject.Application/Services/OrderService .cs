using WebOrderProject.Application.DTOs;
using WebOrderProject.Application.Interfaces;
using WebOrderProject.Infrastructure.Persistence.Repositories;
using WebOrderProject.Domain.Models;
using WebOrderProject.Application.Exceptions;
using static WebOrderProject.Domain.Models.Order;

namespace WebOrderProject.Application.Services;
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderDto?> GetOrderByIdAsync(Guid orderId)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new NotFoundException($"Order with ID {orderId} not found.");

        return new OrderDto
        {
            OrderId = order.OrderId,
            CustomerName = order.CustomerName,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            CreatedAt = order.CreatedAt,
            Products = order.OrderProducts.Select(op => new ProductDto
            {
                ProductId = op.ProductId,
                Name = op.Product.Name,
                Price = op.Product.Price,
                Quantity = op.Quantity
            }).ToList()
        };
    }

    public async Task<List<OrderDto>> GetAllOrdersAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(order => new OrderDto
        {
            OrderId = order.OrderId,
            CustomerName = order.CustomerName,
            Status = order.Status,
            TotalPrice = order.TotalPrice,
            CreatedAt = order.CreatedAt,
            Products = order.OrderProducts.Select(op => new ProductDto
            {
                ProductId = op.ProductId,
                Name = op.Product.Name,
                Price = op.Product.Price,
                Quantity = op.Quantity
            }).ToList()
        }).ToList();
    }

    public async Task<Guid> CreateOrderAsync(OrderDto orderDto)
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid(),
            CustomerName = orderDto.CustomerName,
            Status = orderDto.Status,
            TotalPrice = orderDto.TotalPrice,
            CreatedAt = DateTime.Now,
            OrderProducts = orderDto.Products.Select(p => new OrderProduct
            {
                ProductId = p.ProductId,
                Quantity = p.Quantity
            }).ToList()
        };

        await _orderRepository.AddAsync(order);
        return order.OrderId;
    }

    public async Task UpdateOrderStatusAsync(Guid orderId, OrderStatus status)
    {
        var order = await _orderRepository.GetByIdAsync(orderId);
        if (order == null)
            throw new NotFoundException($"Order with ID {orderId} not found.");

        order.Status = status;
        await _orderRepository.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(Guid orderId)
    {
        await _orderRepository.DeleteAsync(orderId);
    }
}
