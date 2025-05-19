using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Customers.GetCustomer;



[Route("api/[controller]/[action]")]
[ApiController]
public class UpdateCustomerEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpPost]
    public async Task<Result> UpdateCustomer(UpdateCustomerQuery customerQuery)
    {
        return await _mediator.Send(customerQuery);
    }
}
