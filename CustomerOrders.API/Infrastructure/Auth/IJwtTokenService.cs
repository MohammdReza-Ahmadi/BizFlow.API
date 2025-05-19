using BizFlow.API.Common;
using BizFlow.API.Domain.Entities;

namespace BizFlow.API.Infrastructure.Auth;

public interface IJwtTokenService
{
   public Result<string> GenerateJwtToken(User user);
}