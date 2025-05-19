using FluentValidation;

namespace BizFlow.API.Features.Customers.GetCustomer;

public class UpdateCustomerValidator : AbstractValidator<UpdateCustomerQuery>
{
    public UpdateCustomerValidator()
    {
        RuleFor(c => c.Id).NotNull();
        RuleFor(c => c.Role).NotNull();
        RuleFor(c => c.Email).NotNull();
        RuleFor(c => c.FirstName).NotNull();
        RuleFor(c => c.LastName).NotNull();
        RuleFor(c => c.WalletBalance).NotNull();
    }
}
