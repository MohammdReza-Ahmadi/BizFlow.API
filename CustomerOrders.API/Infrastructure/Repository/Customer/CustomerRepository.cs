using BizFlow.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Infrastructure.Repository.Customer;
public class CustomerRepository(Context dbContext) : ICustomerRepository
{
    private readonly Context dbContext = dbContext;
    public async Task<Domain.Entities.Customer> GetAsync(int id,CancellationToken cancellationToken)
    {
        return await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Domain.Entities.Customer customer, CancellationToken cancellationToken)
    {
        var response = await dbContext.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id, cancellationToken);
        response.FirstName = customer.FirstName;
        response.WalletBalance = customer.WalletBalance;
        response.Email = customer.Email;
        response.LastName = customer.LastName;
        response.Role = customer.Role;

        await dbContext.SaveChangesAsync();
    }
}
