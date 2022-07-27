using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Enities;
using Ordering.Infrastructure.Presistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Repositories
{
    public class OrderRespository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRespository(OrderContext dbContext) : base(dbContext)
        {
                
        }
        public  async Task<IEnumerable<Order>> GetOrdersByUserName(string userName)
        {
            var orderlist = await _dbContext.Orders
                           .Where(o => o.UserName == userName)
                           .ToListAsync();


            return orderlist;
        }

       
    }
}
