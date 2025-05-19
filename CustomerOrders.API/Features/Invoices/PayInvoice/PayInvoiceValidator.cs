using BizFlow.API.Features.Invoices.CreateInvoice;
using FluentValidation;

namespace BizFlow.API.Features.Invoices.PayInvoice;

public class PayInvoiceValidator: AbstractValidator<PayInvoiceCommand>
{
    public PayInvoiceValidator()
    {
        RuleFor(i => i.InvoiceId).NotEqual(0);
        RuleFor(i => i.CustomerId).NotEqual(0);
    }
}
