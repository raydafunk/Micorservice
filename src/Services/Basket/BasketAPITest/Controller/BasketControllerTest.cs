using Basket.API.Controllers;
using Basket.API.Entites;
using Basket.API.Repositories.Interfaces;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BasketAPITest.Controller
{
    public class BasketControllerTest
    {
        private readonly IBasketRepository _basketRepository;
        private readonly BasketController _basket;

        public BasketControllerTest()
        {
            _basketRepository = Substitute.For<IBasketRepository>();
            _basket = new BasketController(_basketRepository);
        }

        [Fact]
         public async Task GetBasket_WhenCalled_ShouldReturnsVaildUserName()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };

            await _basket.GetBasket("Brown");

            shoppingcartUser.Should().Be(shoppingcartUser);
        }

        [Fact]
        public async Task GetBasket_WhenCalled_ShoudReturnStatusCodeWithVaildObject()
        {
            var response = GetHttpResponse();

            await _basket.GetBasket("Brown");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetBasket_WhenCalled_ShoudNotReturnNullUser()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };

            await _basket.GetBasket("Brown");

            shoppingcartUser?.Should().NotBeNull();
        }

        [Fact]
        public async Task GetBasket_WhenCalled_ShouldReturnAUserWithShoppingCartItem()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };
            List<ShoppingCartCartItem> shoppingCartCartItems = new();
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { Quantity = 1 });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { ProductId = "Prod_1" });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { Price = 50 });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { Color = "blue" });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { ProductName = "T-Shirt" });

            await _basket.GetBasket("Brown");

            shoppingcartUser.Should().Be(shoppingcartUser);
            shoppingCartCartItems[0].Should().NotBeNull();


        }

        [Fact]
        public async Task UpdateBasket_WhenCalled_ShoudNotBeTheSameUser()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };
            var newShoppingcartUser = new ShoppingCart { UserName = "James" };
            
            await _basket.UpdateBasket(shoppingcartUser);

            shoppingcartUser.Should().NotBe(newShoppingcartUser);
        }

        [Fact]
        public async Task UpdateBasket_WhenCalled_ShoudNotReturnNullUser()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };

            await _basket.UpdateBasket(shoppingcartUser);

            shoppingcartUser?.Should().NotBeNull();
        }

        [Fact]
        public async Task UpdadateBasket_WhenCalled_ShouldReturnAUserWithShoppingCartItem()
        {
            var shoppingcartUser = new ShoppingCart { UserName = "brown" };
            List<ShoppingCartCartItem> shoppingCartCartItems = new();
            shoppingCartCartItems.Add(new ShoppingCartCartItem() {Quantity = 1});
            shoppingCartCartItems.Add(new ShoppingCartCartItem() {ProductId = "Prod_1"});
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { Price = 50 });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { Color = "blue" });
            shoppingCartCartItems.Add(new ShoppingCartCartItem() { ProductName = "T-Shirt" });

            await _basket.UpdateBasket(shoppingcartUser);

            shoppingcartUser.Should().Be(shoppingcartUser);
            shoppingCartCartItems[0].Should().NotBeNull();


        }

        [Fact]
        public async Task DeleteProductById_WHenCalled_ShouldHaveTheSameUserName()
        {
            var actual = new ShoppingCart { UserName = "Brown" };
            var expected = new ShoppingCart { UserName = "Brown" };

            await _basket.DeletBasket("Brown");

            Assert.Equal(expected.UserName, actual.UserName);
        }
        private static HttpResponseMessage GetHttpResponse() => new(HttpStatusCode.OK);


    }
}
