using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Wallet.CreateWallet;

[Route("api/[controller]/[action]")]
[ApiController]
public class CreateWalletEndpoint(IMediator mediator) : ControllerBase
{
    private readonly IMediator mediator = mediator;
    [HttpPost]
    public async Task<Result> CreateWallet(CreateWalletCommand command)
    {
        return await mediator.Send(command);
    }
}
