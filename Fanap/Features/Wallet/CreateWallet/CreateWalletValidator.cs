using FluentValidation;

namespace BizFlow.API.Features.Wallet.CreateWallet;

public class CreateWalletValidator : AbstractValidator<CreateWalletCommand>
{
    public CreateWalletValidator()
    {
        RuleFor(w => w.CustomerId).NotNull();
        RuleFor(w => w.Date).NotNull();
        RuleFor(w => w.Amount).NotNull();
    }
}
