using static WebOrderProject.Domain.Models.Order;
namespace WebOrderProject.Application.DTOs;

public class OrderDto
{
    public Guid OrderId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<ProductDto> Products { get; set; } = new();
}
