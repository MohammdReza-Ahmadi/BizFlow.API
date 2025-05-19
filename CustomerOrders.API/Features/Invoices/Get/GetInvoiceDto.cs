using BizFlow.API.Domain.Entities;

namespace BizFlow.API.Features.Invoices.Get;

public class GetInvoiceDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public decimal Amount { get; set; }
    public DateTime DueDate { get; set; }

    public string Status { get; set; }
}
