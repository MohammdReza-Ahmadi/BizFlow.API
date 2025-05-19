using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Orders.GetOrder;

public record GetOrderQuery(int Id) : IRequest<Result<GetOrderDto>>;
