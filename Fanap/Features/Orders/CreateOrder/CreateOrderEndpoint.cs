using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Orders.CreateOrder;

[Route("api/[controller]/[action]")]
[ApiController]
public class CreateOrderEndpoint(IMediator mediator) : ControllerBase
{
    public readonly IMediator mediator = mediator;
    [HttpPost]
    public async Task<Result> CreateOrder(CreateOrderCommand command)
    {
        return await mediator.Send(command);
    }
}
