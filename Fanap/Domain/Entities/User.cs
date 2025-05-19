using BizFlow.API.Domain.Enums;

namespace BizFlow.API.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required UserRole Role { get; set; }

}
