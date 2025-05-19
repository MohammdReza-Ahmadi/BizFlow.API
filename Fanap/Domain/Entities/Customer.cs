using BizFlow.API.Domain.Enums;

namespace BizFlow.API.Domain.Entities;

public class Customer
{
    public int Id { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }

    public decimal WalletBalance { get; set; }

    public UserRole Role { get; set; }

    public ICollection<Order> Orders { get; set; }
}
