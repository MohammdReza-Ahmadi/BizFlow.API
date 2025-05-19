using BizFlow.API.Domain.Entities;
using BizFlow.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Infrastructure.Repository.Wallet;

public class WalletRepository(Context dbContext) : IWalletRepository
{
    public readonly Context dbContext = dbContext;
    public async Task AddAsync(WalletTransaction walletTransaction, CancellationToken cancellationToken)
    {
        await dbContext.WalletTransactions.AddAsync(walletTransaction, cancellationToken);
    }

    public async Task<WalletTransaction> GetAsync(int id, CancellationToken cancellationToken)
    {
       return await dbContext.WalletTransactions.FirstOrDefaultAsync(w => w.Id == id, cancellationToken);
    }
}
