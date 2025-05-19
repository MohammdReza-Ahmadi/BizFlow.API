using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Invoices.Get;

[Route("api/[controller]")]
[ApiController]
public class GetInvoiceEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;
    [HttpGet]
    public async Task<Result<List<GetInvoiceDto>>> GetInvoice(GetInvoicesQuery query)
    {
      return await _mediator.Send(query);
    }
}
