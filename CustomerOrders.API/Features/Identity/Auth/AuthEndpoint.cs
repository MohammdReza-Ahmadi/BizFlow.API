using BizFlow.API.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizFlow.API.Features.Identity.Auth
{

    [Route("api/auth")]
    [ApiController]
    public class AuthEndpoint(IMediator mediator) : ControllerBase
    {
        public readonly IMediator mediator = mediator;

        [HttpPost("login")]
        public async Task<Result<AuthDto>> Login(AuthQuery query)
        {
            return await mediator.Send(query);
        }
    }

}
