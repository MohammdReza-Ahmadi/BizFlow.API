using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Customer;
using MediatR;

namespace BizFlow.API.Features.Customers.Customer;

public class GetCustomerQueryHandler(ICustomerRepository repository) : IRequestHandler<GetCustomerQuery, Result<CustomerResponse>>
{
    private readonly ICustomerRepository repository = repository;

    public async Task<Result<CustomerResponse>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
    {
        var response = await repository.GetAsync(request.Id, cancellationToken);
        return Result<CustomerResponse>.Ok(new CustomerResponse
        {
            Id = response.Id,
            Email = response.Email,
            FirstName = response.FirstName,
            LastName = response.LastName,
            Orders = response.Orders,
            Role = response.Role,
            WalletBalance = response.WalletBalance,

        });
    }
}
