using Catalog.API.Repositories.Interface;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPITest.Respository
{
    public  class ProductRespositoryTest
    {
        private readonly IProductRespository _respository;

        public ProductRespositoryTest()
        {
            _respository = Substitute.For<IProductRespository>();
        }

    }
}
