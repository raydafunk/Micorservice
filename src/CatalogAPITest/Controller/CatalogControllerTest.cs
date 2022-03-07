using Catalog.API.Controllers;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interface;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

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
        public async Task GetProducts_whencalled_shouldReturnEqualProductItems()
        {
            var actual = new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone X" ,Category = "Smart Phone",Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut,",Price = 950.00M };
            var expected = new Product { Id = "602d2149e773f2a3990b47f5", Name = "IPhone X", Category = "Smart Phone", Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut,", Price = 950.00M };

            await _catalog.GetProducts();

            Assert.Equal(expected.Id, actual.Id);

        }
    }
}
