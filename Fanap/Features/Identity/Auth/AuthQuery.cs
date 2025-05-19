using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Identity.Auth;

public record AuthQuery(string Email, string Password) : IRequest<Result<AuthDto>>;

