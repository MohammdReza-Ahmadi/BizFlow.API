using System.IdentityModel.Tokens.Jwt;

namespace BizFlow.API.Common;

public class JwtExpiryMiddleware
{
    private readonly RequestDelegate _next;

    public JwtExpiryMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Replace("Bearer ", "");

        if (!string.IsNullOrEmpty(token))
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var jwtToken = handler.ReadJwtToken(token);

                var expiry = jwtToken.ValidTo;

                if (expiry < DateTime.UtcNow)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("توکن منقضی شده است.");
                    return;
                }
            }
            catch (Exception)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("توکن نامعتبر است.");
                return;
            }
        }

        await _next(context);
    }
}
