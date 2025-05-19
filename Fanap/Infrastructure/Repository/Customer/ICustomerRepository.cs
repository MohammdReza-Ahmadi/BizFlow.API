namespace BizFlow.API.Infrastructure.Repository.Customer;

public interface ICustomerRepository
{
   Task<Domain.Entities.Customer> GetAsync(int id, CancellationToken cancellationToken);
   Task UpdateAsync(Domain.Entities.Customer customer, CancellationToken cancellationToken);
}
