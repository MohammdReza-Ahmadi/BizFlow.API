using BizFlow.API.Domain.Entities;

namespace BizFlow.API.Features.Wallet.GetWallet;

public class GetWalletDto
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public string? Description { get; set; }
}
