using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Invoice;
using MediatR;

namespace BizFlow.API.Features.Invoices.CreateInvoice
{
    public class CreateInvoiceCommandHandler(IInvoiceRepository repository) : IRequestHandler<CreateInvoiceCommand, Result>
    {
        private readonly IInvoiceRepository repository = repository;
        public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            await repository.AddInvoiceAsync(new Domain.Entities.Invoice
            {
                Amount = request.Amount,
                DueDate = request.DueDate,
                OrderId = request.OrderId,
                Status = request.Status,
            },cancellationToken);
            return Result.Ok();
        }
    }
}
