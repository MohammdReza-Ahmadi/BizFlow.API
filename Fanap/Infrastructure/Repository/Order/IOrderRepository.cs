namespace BizFlow.API.Infrastructure.Repository.Order;

public interface IOrderRepository
{
    Task AddAsync(Domain.Entities.Order order, CancellationToken cancellationToken);

    Task<Domain.Entities.Order> GetAsync(int id, CancellationToken cancellationToken);
}
