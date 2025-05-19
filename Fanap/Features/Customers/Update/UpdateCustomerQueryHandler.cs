using BizFlow.API.Common;
using BizFlow.API.Infrastructure.Repository.Customer;
using MediatR;

namespace BizFlow.API.Features.Customers.GetCustomer;

public class UpdateCustomerQueryHandler(ICustomerRepository repository) : IRequestHandler<UpdateCustomerQuery, Result>
{
    private readonly ICustomerRepository repository = repository;

    public async Task<Result> Handle(UpdateCustomerQuery request, CancellationToken cancellationToken)
    {
        await repository.UpdateAsync(new Domain.Entities.Customer
        {
            Id = request.Id,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Role = request.Role,
            WalletBalance = request.WalletBalance,
        },cancellationToken);
        return Result.Ok();
    }
}
