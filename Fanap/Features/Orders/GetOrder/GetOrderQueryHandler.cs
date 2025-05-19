using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Persistence;
using BizFlow.API.Infrastructure.Repository.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Features.Orders.GetOrder;

public class GetOrderQueryHandler(IOrderRepository orderRepository) : IRequestHandler<GetOrderQuery, Result<GetOrderDto>>
{
    private readonly IOrderRepository orderRepository = orderRepository;
    public async Task<Result<GetOrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await orderRepository.GetAsync(request.Id,cancellationToken);
        if (order == null)
            return Result<GetOrderDto>.Fail("سفارشی یافت نشد");
        return Result<GetOrderDto>.Ok(
            new GetOrderDto
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                OrderDate = order.OrderDate,
                Quantity = order.Quantity,
                Product = order.Product,
                TotalAmount = order.TotalAmount,
                Invoice = order.Invoice,
                Customer = order.Customer,
            });
    }
}
