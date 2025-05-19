using FluentValidation;

namespace BizFlow.API.Features.Invoices.CreateInvoice
{
    public class CreateInvoiceValidator: AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceValidator()
        {
            RuleFor(i => i.OrderId).NotNull();
            RuleFor(i => i.Amount).NotNull();
            RuleFor(i => i.DueDate).NotNull();
            RuleFor(i => i.Status).NotNull();
        }
    }
}
