using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Invoices.PayInvoice;

[Route("api/[controller]")]
[ApiController]
public class PayInvoiceEndpoint(IMediator mediator) : ControllerBase
{
    public readonly IMediator mediator = mediator;

    public async Task<Result> PayInvoice(PayInvoiceCommand command)
    {
        return await mediator.Send(command);
    }
}
