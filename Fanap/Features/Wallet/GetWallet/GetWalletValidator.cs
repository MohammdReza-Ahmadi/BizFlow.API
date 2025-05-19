using FluentValidation;

namespace BizFlow.API.Features.Wallet.GetWallet;

public class GetWalletValidator: AbstractValidator<GetWalletQuery>
{
    public GetWalletValidator()
    {
        RuleFor(w => w.Id).NotNull();
    }
}
