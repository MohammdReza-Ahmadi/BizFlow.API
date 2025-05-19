namespace BizFlow.API.Domain.Entities;

public class WalletTransaction
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public string? Description { get; set; }
}
