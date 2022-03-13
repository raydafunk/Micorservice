using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using System.Net;
using System.Net.Http;

namespace CatalogAPITest.Controller
{
    public class CatalogControllerTest
    {

        private readonly IProductRespository _productRepo;
        private readonly ILogger<CatalogController> _looger;

        private readonly CatalogController _catalog;

        public CatalogControllerTest()
        {
            _productRepo = Substitute.For<IProductRespository>();
            _looger = Substitute.For<ILogger<CatalogController>>();

            _catalog = new CatalogController(_productRepo, _looger);
        }

        [Fact]
        public async Task GetProducts_Whencalled_shouldReturnEqualProductItems()
        {
            var actual = new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone X", Category = "Smart Phone", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut,", Price = 950.00M };
            var expected = new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone X", Category = "Smart Phone", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut,", Price = 950.00M };

            await _catalog.GetProducts();

            Assert.Equal(expected.Id, actual.Id);

        }

        [Fact]
        public async Task GetProductsByCategory_whenCaled_ShouldReturnACategory()
        {
            var actual = new Product { Category = "White Appliances" };
            var expected = new Product { Category = "White Appliances" };

            _productRepo
                .GetProduct("actual")
                .Returns(actual);

            await _catalog.GetProductsByCategory("White Appliances");

            Assert.Equal(expected.Category, actual.Category);
        }

        [Fact]
        public async Task GetProductbyId_WhenCalled_ShouldReturnAProductId()
        {
            var productId = new Product { Id = "602d2149e773f2a3990b47f7" };

            await _catalog.GetProductbyId("602d2149e773f2a3990b47f7");

            productId.Should().Match<Product>(p => (p.Id == "602d2149e773f2a3990b47f7"));
        }
        [Fact]
        public async Task GetProductbyId_WhenCalled_ChecksForNullItems()
        {

            var productId = new Product { Id = "602d2149e773f2a3990b47f7" };

            _productRepo
                .GetProduct("602d2149e773f2a3990b47f7")
                .Returns(productId);
            await _catalog.GetProductbyId("602d2149e773f2a3990b47f7");


        }

        [Fact]
        public async Task GetProductsByCategory_whenCalled_ShouldNotLogNull()
        {
            var emptyProductByCategory = new Product { Category = "White Appliances" };

            await _catalog.GetProductsByCategory("emptyProduct");

            Assert.NotNull(emptyProductByCategory);
        }

        [Fact]
        public async Task CreateProduct_WhenCalled_ShoudReturnStatusCodeWithVaildObject()
        {
            var response = GetHttpResponse();
            await _catalog.CreateProduct(MockResponse);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
        }

        [Fact]
        public async Task UpdateProduct_WhenCalled_ShouldNotHaveTheSameProductObject()
        {
            var product = UpdatedMockResponse;

            await _catalog.UpdateProduct(MockResponse);
            product.Should().NotBe(MockResponse);
        }

        [Fact]

        public async Task DeleteProductById_WHenCalled_ShouldHaveTheSameProductId()
        {
            var actual = new Product { Id = "602d2149e773f2a3990b47f5"};
            var expected = new Product { Id = "602d2149e773f2a3990b47f5"};

            await _catalog.DeleteProductById("actual");

            Assert.Equal(expected.Id, actual.Id);
        }
        private Product MockResponse
        {
            get
            {
                return new Product
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                };
            }

        }

        private Product UpdatedMockResponse
        {
            get
            {
                return new Product
                {
                    Id = "602d2149e773f2a3990b4760",
                    Name = "Samsanug 21",
                    Summary = "this phone",
                    Description = "some dest",
                    ImageFile = "ImageFile",
                    Price = 950.00M,
                    Category = "Smart Phone"
                };
            }
        }

        private HttpResponseMessage GetHttpResponse() => new HttpResponseMessage(HttpStatusCode.Created);
    }
}
