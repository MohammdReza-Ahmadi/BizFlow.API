using BizFlow.API.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BizFlow.API.Infrastructure.Repository.Order;
public class OrderRepository(Context context) : IOrderRepository
{
    public readonly Context context  = context;

    public async Task AddAsync(Domain.Entities.Order order, CancellationToken cancellationToken)
    {
        await context.AddAsync(order,cancellationToken);
    }

    public async Task<Domain.Entities.Order> GetAsync(int id,CancellationToken cancellationToken)
    {
        return await context.Orders.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }
}
