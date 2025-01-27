using WebOrderProject.Domain.Models;
using WebOrderProject.Infrastructure.Persistence.Configurations;
using WebOrderProject.Infrastructure.Persistence.Repositories;
using static WebOrderProject.Domain.Models.Order;

public class Program
{
    private readonly IOrderRepository _orderRepository;

    public CreateOrderUseCase(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    public static async Task Main(string[] args)
    {
        var order = new Order
        {
            OrderId = Guid.NewGuid(),
            CustomerName = "John Doe",
            Status = OrderStatus.Pending,
            TotalPrice = 100.00m,
            CreatedAt = DateTime.Now,
            OrderProducts = new List<OrderProduct>
        {
        new OrderProduct
        {
            ProductId = Guid.NewGuid(),
            Quantity = 2
        }
        }
        };
        OrderRepository orderRepository;

        await orderRepository.AddAsync(order);
    }
}