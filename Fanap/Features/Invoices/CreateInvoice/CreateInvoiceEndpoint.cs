using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Invoices.CreateInvoice;

[Route("api/[controller]")]
[ApiController]
public class CreateInvoiceEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    public async Task<Result> CreateInvoice(CreateInvoiceCommand command)
    { 
        return await _mediator.Send(command);
    }
}
