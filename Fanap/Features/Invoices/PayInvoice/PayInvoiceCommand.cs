using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Invoices.PayInvoice;

public record PayInvoiceCommand(int InvoiceId,int CustomerId) : IRequest<Result>;
