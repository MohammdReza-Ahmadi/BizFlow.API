using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Wallet;
using MediatR;

namespace BizFlow.API.Features.Wallet.CreateWallet;

public class CreateWalletCommandHandler(IWalletRepository repository) : IRequestHandler<CreateWalletCommand, Result>
{
    private readonly IWalletRepository repository = repository;
    public async Task<Result> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
    {
        await repository.AddAsync(new Domain.Entities.WalletTransaction
        {
            Amount = request.Amount,
            Date = request.Date,
            CustomerId = request.CustomerId,
            Description = request.Description,
        },cancellationToken);
        return Result.Ok();
    }
}
