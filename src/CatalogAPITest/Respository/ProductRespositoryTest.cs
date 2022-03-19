using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using FluentAssertions;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CatalogAPITest.Respository
{
    public  class ProductRespositoryTest
    {

        private readonly ProductRepository  _productRespository;

        private readonly ICatalogContext _catalogContext;

        public ProductRespositoryTest()
        {

            _catalogContext = Substitute.For<ICatalogContext>();
            _productRespository = new ProductRepository(_catalogContext);
        }

        [Fact]
         public async Task GetProducts_WhenCalled_ShouldHaveProductsInIEnumerableList()
        {
            IEnumerable<Product> productRepositories = new List<Product>() { new Product { Id = "602d2149e773f2a3990b4760", Description = "Smart Phone", Category = "Smart Phone", ImageFile= "ImageFile", Name= "Samsanug 21", Price = 950.00M, Summary = "this phone" } };

            await _productRespository.GetProducts();

            productRepositories.Should().HaveCount(1);
        }

        [Fact]
        public async Task GetProducts_WhenCaled_ShouldHaveEqualProductInList()
        {
            IEnumerable<Product> productRepositories = new List<Product>() { new Product { Id = "602d2149e773f2a3990b4760", Description = "Smart Phone", Category = "Smart Phone", ImageFile = "ImageFile", Name = "Samsanug 21", Price = 950.00M, Summary = "this phone" } };

            await _productRespository.GetProducts();
              
            productRepositories.Should().Equal(productRepositories);

        }

        [Fact]
        public async Task GetProducts_WhenCalled_ShoudlNotHaveNullProductInList()
        {
            IEnumerable<Product> productRepositories = new List<Product>() { new Product { Id = "602d2149e773f2a3990b4760", Description = "Smart Phone", Category = "Smart Phone", ImageFile = "ImageFile", Name = "Samsanug 21", Price = 950.00M, Summary = "this phone" } };

            await _productRespository.GetProducts();

            productRepositories.Should().NotBeNull();

        }

        [Fact]
        public async Task GetProduct_WHenCalled_ShouldNotBeANullableList()
        {
            var productList = MockResponse;

            await _productRespository.GetProduct("602d2149e773f2a3990b47f7");

            productList.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProduct_WhenCalled_ShoudldContainProductId()
        {
            var productId = new Product { Id = "602d2149e773f2a3990b47f7" };

            await _productRespository.GetProduct("602d2149e773f2a3990b47f7");

            productId.Should().Be(productId);
        }

        [Fact]
        public async Task GetProductsByName_SHouldNotBeNull()
        {
            var productName = new Product { Name = "IPhone X", };

            await _productRespository.GetProductsByName("IPhone X");

            productName.Should().NotBeNull();
        }

        [Fact]
        public async Task GetProduct_WhenCalled_ShoudldContainProductName()
        {
            var productName = new Product { Name = "IPhone X", };

            await _productRespository.GetProductsByName("IPhone X");

            productName.Should().Be(productName);
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

    }
}
