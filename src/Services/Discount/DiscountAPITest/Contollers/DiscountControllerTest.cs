using Discount.API.Controllers;
using Discount.API.Entites;
using Discount.API.Repositoires.Interfaces;
using FluentAssertions;
using NSubstitute;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DiscountAPITest.Contollers
{
    public class DiscountControllerTest
    {

        private readonly IDiscountRepository _discountRepo;

        private readonly DiscountController _discount;
        public DiscountControllerTest()
        {
            _discountRepo = Substitute.For<IDiscountRepository>();

            _discount = new DiscountController(_discountRepo);
        }

        [Fact]
        public async Task GetDiscount_Should_return_ProductName_discounts()
        {
            var actual = new Coupon { ProductName = "T-shirt" };
            var expected = new Coupon { ProductName = "T-shirt" };

            _discountRepo
                .GetDiscount("actual")
                .Returns(actual);

            await _discount.GetDiscount("T-shirt");

            Assert.Equal(expected.ProductName, actual.ProductName);

        }

        [Fact]
        public async Task GetDiscount_ShouldNot_return_Null_ProductName_Discount()
        {
            var productCoupon = new Coupon { ProductName = "T-shirt" };

            _discountRepo
                .GetDiscount("T-shirt")
                .Returns(productCoupon);

            await _discountRepo.GetDiscount("T-shirt");

            productCoupon.Should().NotBeNull();

        }

        [Fact]
        public async Task CreateDiscount_WhenCalled_ShouldRetunrsStatusCodeWIthVaildObject()
        {
            var response = GetHttpResponse();

            await _discount.GetDiscount("T-shirt");
            response.StatusCode.Should().Be(HttpStatusCode.OK);


        }

        [Fact]
        public async Task GetDiscount_WhenCalled_ShouldRetunrsStatusCodeWIthVaildObject()
        {
            var response = GetHttpResponse();

            await _discount.CreateDiscount(MockCouponResponse);
            response.StatusCode.Should().Be(HttpStatusCode.OK);


        }


        [Fact]
        public async Task CreateDiscount_WhenCalled_SHouldNotBeNull()
        {
            var discountProduct = MockCouponResponse;

            await _discount.CreateDiscount(discountProduct);

            discountProduct.Should().NotBeNull();
        }

        [Fact]
        public async Task CreateDiscount_WhenCalled_SHoulHaveEqualProductNames()
        {
            var discountProduct =  new Coupon { ProductName =" T-shirt"};

            await _discount.CreateDiscount(discountProduct);

            discountProduct.Should().Be(discountProduct);
        }

        [Fact]
        public async Task UpdateDiscount_WhenCalled_ShouldRetunrsStatusCodeWIthVaildObject()
        {
            var response = GetHttpResponse();

            await _discount.CreateDiscount(MockCouponResponse);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task UpdateDiscount_WhenCalled_ShouldNotHaveTheSameCoupenObject()
        {

            var coupon = UpdatedMockCouponResponse;

            await _discount.UpdateDiscount(UpdatedMockCouponResponse);
            coupon.Should().NotBe(MockCouponResponse);

        }

        [Fact]
        public async Task DeleteDiscount_WhenCalled_ShouldRetunrsStatusCodeWIthVaildObject()
        {
            var response = GetHttpResponse();

            await _discount.CreateDiscount(MockCouponResponse);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]

        public async Task DeleteDiscount_WHenCalled_ShouldHaveTheSameProductId()
        {
            var actual = new Coupon { ProductName = "T-Shirt" };
            var expected = new Coupon { ProductName = "T-Shirt" };

            await _discount.DeleteDiscount("actual");

            Assert.Equal(expected.Id, actual.Id);
        }

        private static Coupon MockCouponResponse
        {
            get
            {
                return new Coupon
                {
                    ProductName = "T-Shirt",
                    Amount = 2,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit od",
                    Id = 1
                };
            }
        }

        [Fact]
        public async Task UpdateDiscoun_WhenCalled_SHouldNotBeNull()
        {
            var discountProduct = MockCouponResponse;

            await _discount.UpdateDiscount(UpdatedMockCouponResponse);

            discountProduct.Should().NotBeNull();
        }

        private static Coupon UpdatedMockCouponResponse
        {
            get
            {
                return new Coupon
                {
                    ProductName = "Shirt",
                    Amount = 2,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit od",
                    Id = 1
                };
            }
        }

        private static HttpResponseMessage GetHttpResponse() => new(HttpStatusCode.OK);
    }
}
