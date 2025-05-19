using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Invoices.Get
{
    public record GetInvoicesQuery : IRequest<Result<List<GetInvoiceDto>>>;
}
