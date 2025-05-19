using BizFlow.API.Domain.Enums;

namespace BizFlow.API.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }

    public InvoiceStatus Status { get; set; }
}
