using BizFlow.API.Domain.Entities;

namespace BizFlow.API.Infrastructure.Repository.Wallet;

public interface IWalletRepository
{
    Task AddAsync(WalletTransaction walletTransaction, CancellationToken cancellationToken);

    Task<WalletTransaction> GetAsync(int id, CancellationToken cancellationToken);
}
