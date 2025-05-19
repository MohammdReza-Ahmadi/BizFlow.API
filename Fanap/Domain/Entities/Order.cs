namespace BizFlow.API.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public string? Product { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }

    public DateTime OrderDate { get; set; }
    public int InvoiceId { get; set; }
    public Invoice? Invoice { get; set; }
}
