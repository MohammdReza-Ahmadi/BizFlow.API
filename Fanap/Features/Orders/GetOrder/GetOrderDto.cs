using BizFlow.API.Domain.Entities;

namespace BizFlow.API.Features.Orders.GetOrder;

public class GetOrderDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public string? Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }

    public Invoice? Invoice { get; set; }
}
