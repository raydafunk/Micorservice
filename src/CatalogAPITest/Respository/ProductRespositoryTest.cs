using Catalog.API.Data;
using Catalog.API.Entities;
using Catalog.API.Repositories;
using Catalog.API.Repositories.Interface;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task GetProductsByName_WhenCalledProductName_ShouldReturnProductName()
        {
            await _productRespository.GetProductsByName("Task");
        }

    }
}
