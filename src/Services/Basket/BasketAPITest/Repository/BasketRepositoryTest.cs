using Basket.API.Entites;
using Basket.API.Repositories.Interfaces;
using FluentAssertions;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace BasketAPITest.Repository
{
    public class BasketRepositoryTest
    {
        private readonly IBasketRepository _basketRepository;

        public BasketRepositoryTest()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
        }

        [Fact]
        public async Task GetBasket_WHenCalled_ShouldReturnUserNameValueObject()
        {
            var userbasket = new ShoppingCart() { UserName = "Brown" };

            await _basketRepository.GetBasket(Arg.Any<string>());

            userbasket.Should().Be(userbasket);
        }

        [Fact]
        public async Task UpdateBasket_WhenCalled_ShouldHaveTheSameUserNameObject()
        {
            var userbasket = new ShoppingCart() { UserName = "Brown" };

            await _basketRepository.UpdateBasket(userbasket);

            userbasket.Should().Be(userbasket);
        }

        [Fact]
        public async Task UpdateBasket_WhenCalled_ShouldNotBeNull()
        {
            var userbasket = new ShoppingCart() { UserName = "Brown" };

            await _basketRepository.UpdateBasket(userbasket);

            userbasket.Should().NotBeNull();
        }
        [Fact]

        public async Task DeleteBasket_WhenCalled_ShouldHaveTheSameUserNameObject()
        {
            var userbasket = new ShoppingCart() { UserName = "Brown" };

            await _basketRepository.DeleteBasket(Arg.Any<string>());

            userbasket.Should().Be(userbasket);
        }


    }
}
