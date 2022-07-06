using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Enities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Presistance
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> option) : base(option)
        {
                
        }
        public DbSet<Order> Orders { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "rbc";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "rbc";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
