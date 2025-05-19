using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Wallet.GetWallet;

[Route("api/[controller]/[action]")]
[ApiController]
public class GetWalletEndpoint(IMediator mediator) : ControllerBase
{
    public readonly IMediator mediator = mediator;

    [HttpGet]
    public async Task<Result<GetWalletDto>> GetWallet(GetWalletQuery query)
    {
        return await mediator.Send(query);
    }
}
