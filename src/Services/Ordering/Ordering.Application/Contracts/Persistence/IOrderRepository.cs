using Ordering.Domain.Enities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ordering.Application.Contracts.Persistence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
        Task<IAsyncEnumerable<Order>> GetOrdersByUserName(string userName);
    }
}
