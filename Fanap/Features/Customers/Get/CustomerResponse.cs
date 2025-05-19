using BizFlow.API.Domain.Entities;
using BizFlow.API.Domain.Enums;

namespace BizFlow.API.Features.Customers.Customer;

public class CustomerResponse
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public decimal WalletBalance { get; set; }
    public UserRole Role { get; set; }
    public required ICollection<Order> Orders { get; set; }
}
