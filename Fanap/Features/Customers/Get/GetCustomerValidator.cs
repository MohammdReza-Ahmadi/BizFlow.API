using FluentValidation;

namespace BizFlow.API.Features.Customers.Customer;

public class GetCustomerValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerValidator()
    {
        RuleFor(c => c.Id).NotNull();
    }
}
