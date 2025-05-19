using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Invoice;
using MediatR;

namespace BizFlow.API.Features.Invoices.PayInvoice;

public class PayInvoiceHandler(IInvoiceRepository invoiceRepository) : IRequestHandler<PayInvoiceCommand, Result>
{
    private readonly IInvoiceRepository invoiceRepository = invoiceRepository;


    public async Task<Result> Handle(PayInvoiceCommand request, CancellationToken cancellationToken)
    {
      return  await invoiceRepository.PayInvoice(request.InvoiceId, request.CustomerId, cancellationToken);
    }
}