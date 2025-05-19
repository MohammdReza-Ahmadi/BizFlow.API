using BizFlow.API.Common;
using MediatR;

namespace BizFlow.API.Features.Customers.Customer;

public record GetCustomerQuery(int Id) : IRequest<Result<CustomerResponse>>;
