using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Wallet;
using MediatR;

namespace BizFlow.API.Features.Wallet.GetWallet;

public class GetWalletQueryHandler(IWalletRepository repository) : IRequestHandler<GetWalletQuery, Result<GetWalletDto>>
{
    public readonly IWalletRepository repository = repository;

    public async Task<Result<GetWalletDto>> Handle(GetWalletQuery request, CancellationToken cancellationToken)
    {
        var wallet = await repository.GetAsync(request.Id, cancellationToken);
        return Result<GetWalletDto>.Ok(new GetWalletDto
        {
            Id = wallet.Id,
            Amount = wallet.Amount,
            CustomerId = wallet.CustomerId,
            Date = wallet.Date,
            Description = wallet.Description,
        });
    }
}
