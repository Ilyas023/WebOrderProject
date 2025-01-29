using static WebOrderProject.Domain.Models.Order;

namespace WebOrderProject.Application.DTOs;

public class CutOrderDto
{
    public string CustomerName { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
    public List<ProductForOrder> Products { get; set; } = new();
}

public class ProductForOrder
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

