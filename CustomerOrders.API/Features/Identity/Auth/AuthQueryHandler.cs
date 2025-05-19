using BizFlow.API.Common;
using BizFlow.API.Domain.Entities;
using BizFlow.API.Infrastructure.Auth;
using MediatR;

namespace BizFlow.API.Features.Identity.Auth
{
    public class AuthQueryHandler(IJwtTokenService jwtService) : IRequestHandler<AuthQuery, Result<AuthDto>>
    {
        private readonly IJwtTokenService jwtService = jwtService;
        public Task<Result<AuthDto>> Handle(AuthQuery request, CancellationToken cancellationToken)
        {
            if (request.Email == "admin@test.com" && request.Password == "123456")
            {
                var user = new User
                {
                    Id = 1,
                    Email = request.Email,
                    Password = request.Password,
                    Role = Domain.Enums.UserRole.Admin
                };
                var token = jwtService.GenerateJwtToken(user).Data;
                if (string.IsNullOrEmpty(token))
                    return Task.FromResult(Result<AuthDto>.Fail("برای این یوزر توکنی ایجاد نشد"));
                return Task.FromResult(Result<AuthDto>.Ok(new AuthDto { Token = token }));
            }
            return Task.FromResult(Result<AuthDto>.Fail("برای این یوزر توکنی ایجاد نشد"));
        }
    }
}
