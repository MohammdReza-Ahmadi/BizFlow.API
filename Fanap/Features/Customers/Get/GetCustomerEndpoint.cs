using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Customers.Customer;



[Route("api/[controller]/[action]")]
[ApiController]
public class GetCustomerEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<Result<CustomerResponse>> GetCustomer(GetCustomerQuery customerQuery)
    {
        return await _mediator.Send(customerQuery);
    }
}
