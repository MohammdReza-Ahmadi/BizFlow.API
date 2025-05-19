using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Persistence;
using BizFlow.API.Infrastructure.Repository.Invoice;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Features.Invoices.Get
{
    public class GetInvoicesQueryHandler(IInvoiceRepository repository) : IRequestHandler<GetInvoicesQuery, Result<List<GetInvoiceDto>>>
    {
        private readonly IInvoiceRepository repository = repository;

        public async Task<Result<List<GetInvoiceDto>>> Handle(GetInvoicesQuery request, CancellationToken cancellationToken)
        {
            var response = await repository.GetInvoicesAsync(cancellationToken);
            var invoices = response.Select(i => new GetInvoiceDto
            {
                Id = i.Id,
                Order = i.Order,
                OrderId = i.OrderId,
                Amount = i.Amount,
                DueDate = i.DueDate,
                Status = i.Status.ToString(),
            }).ToList();
            return Result<List<GetInvoiceDto>>.Ok(invoices);
        }
    }
}
