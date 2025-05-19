using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Wallet.CreateWallet;

public record CreateWalletCommand(int CustomerId, decimal Amount, DateTime Date, string? Description):IRequest<Result>;
