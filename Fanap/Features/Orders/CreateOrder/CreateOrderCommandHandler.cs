using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Order;
using MediatR;

namespace BizFlow.API.Features.Orders.CreateOrder;

public class CreateOrderCommandHandler(IOrderRepository repository) : IRequestHandler<CreateOrderCommand, Result>
{
    private readonly IOrderRepository repository = repository;
    public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
         await repository.AddAsync(new Domain.Entities.Order
        {
            CustomerId = request.CustomerId,
            OrderDate = request.OrderDate,
            Product = request.Product,
            Quantity = request.Quantity,
            TotalAmount = request.TotalAmount,
            InvoiceId = request.InvoiceId,
        },cancellationToken);
        return Result.Ok();
    }
}
