using BizFlow.API.Common;
using BizFlow.API.Domain.Enums;
using MediatR;

namespace BizFlow.API.Features.Invoices.CreateInvoice
{
    public record CreateInvoiceCommand(int OrderId, decimal Amount, DateTime DueDate, InvoiceStatus Status) :IRequest<Result>;

}
