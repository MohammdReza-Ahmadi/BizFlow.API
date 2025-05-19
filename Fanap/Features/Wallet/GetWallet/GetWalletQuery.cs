using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Wallet.GetWallet;

public record GetWalletQuery(int Id) : IRequest<Result<GetWalletDto>>;
