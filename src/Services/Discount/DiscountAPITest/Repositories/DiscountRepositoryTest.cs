using Discount.API.Repositoires;
using Microsoft.Extensions.Configuration;
using NSubstitute;

namespace DiscountAPITest.Repositories
{
    public class DiscountRepositoryTest
    {
        private readonly DiscountRepository _discountRepository;
        private readonly IConfiguration _configuration;

        public DiscountRepositoryTest()
        {
            _configuration = Substitute.For<IConfiguration>();
            _discountRepository = new DiscountRepository(_configuration);
        }
    }
}
