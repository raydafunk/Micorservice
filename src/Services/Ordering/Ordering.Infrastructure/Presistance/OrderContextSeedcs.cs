using Microsoft.Extensions.Logging;
using Ordering.Domain.Enities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Presistance
{
    public  class OrderContextSeedcs
    {
        public static async Task CreateSeedcs(OrderContext orderContext, ILogger<OrderContextSeedcs> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database assicoated  wit the context {DbContextName}", typeof(OrderContext).Name);
            }

           
        }

       private  static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() {UserName = "rbc", FirstName = "Ray", LastName ="Brown-Amory", EmailAddress = "raybrown@exmaple", AddressLine ="Banchelor street",Country ="England"}
            };
        }

    }
}
