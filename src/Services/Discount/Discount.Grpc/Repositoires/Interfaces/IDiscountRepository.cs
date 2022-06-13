using Discount.Grpc.Entites;
using System.Threading.Tasks;

namespace Discount.Grpc.Repositoires.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productname);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool>DeleteDiscount(string productname);
    }
}
