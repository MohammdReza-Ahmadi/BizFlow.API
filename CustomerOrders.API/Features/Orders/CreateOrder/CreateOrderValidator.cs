using FluentValidation;

namespace BizFlow.API.Features.Orders.CreateOrder;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(o => o.CustomerId).NotNull();
        RuleFor(o => o.InvoiceId).NotNull();
        RuleFor(o => o.Product).NotNull();
        RuleFor(o => o.Quantity).NotNull();
        RuleFor(o => o.TotalAmount).NotNull();
        RuleFor(o => o.OrderDate).NotNull();
    }
}
