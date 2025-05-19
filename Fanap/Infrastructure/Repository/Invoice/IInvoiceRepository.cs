using BizFlow.API.Common;

namespace BizFlow.API.Infrastructure.Repository.Invoice;

public interface IInvoiceRepository
{
    Task AddInvoiceAsync(Domain.Entities.Invoice invoice, CancellationToken cancellationToken);
    Task<List<Domain.Entities.Invoice>> GetInvoicesAsync(CancellationToken cancellationToken);
    Task<Result> PayInvoice(int invoiceId, int customerId, CancellationToken cancellationToken);
}
