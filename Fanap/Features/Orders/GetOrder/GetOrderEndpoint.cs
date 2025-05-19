using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Orders.GetOrder;

[Route("api/[controller]/[action]")]
[ApiController]
public class GetOrderEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<Result<GetOrderDto>> GetOrder(GetOrderQuery query)
    {
        return await _mediator.Send(query);
    }
}
