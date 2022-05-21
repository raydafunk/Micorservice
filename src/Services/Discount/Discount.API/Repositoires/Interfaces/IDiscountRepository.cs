using Discount.API.Entites;
using System.Threading.Tasks;

namespace Discount.API.Repositoires.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Coupon> GetDiscount(string productname);

        Task<bool> CreateDiscount(Coupon coupon);
        Task<bool> UpdateDiscount(Coupon coupon);
        Task<bool>DeleteDiscount(string productname);
    }
}
