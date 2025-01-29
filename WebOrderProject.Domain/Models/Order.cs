using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WebOrderProject.Domain.Models.Order;

namespace WebOrderProject.Domain.Models;

public class Order
{
    public Guid OrderId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();


    public Order()
    {
        OrderId = Guid.NewGuid();
    }

    public enum OrderStatus
    {
        Pending,
        Confirmed,
        Cancelled
    }


}
