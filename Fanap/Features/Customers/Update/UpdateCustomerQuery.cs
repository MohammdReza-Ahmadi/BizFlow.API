using BizFlow.API.Common;
using BizFlow.API.Domain.Enums;
using MediatR;

namespace BizFlow.API.Features.Customers.GetCustomer;

public record UpdateCustomerQuery(int Id, string? FirstName, string? LastName, string? Email, decimal WalletBalance, UserRole Role) : IRequest<Result>;
