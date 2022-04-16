using Moq;
using Nivello.Domain.Queries.Products.Queries;
using Nivello.Domain.Queries.Products.QueryHandlers;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Queries.Products.QueryHandlers
{
    public class GetAllProductsQueryHandlerTest
    {
        private List<Product> products;
        private Mock<IProductRepository> _productRepository;
        private byte[] mockImage { get; set; } = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [SetUp]
        public void Setup()
        {
            products = new List<Product>()
            {
                new Product("Tv 42 Polegadas", 200, mockImage, Guid.NewGuid(), null, null),
                new Product("Bicicleta", 500, mockImage, Guid.NewGuid(), null, null),
            };
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(products);
        }

        [Test]
        public async Task When_Find_All_Products_IsOkAsync()
        {
            var handler = new GetAllProductsQueryHandler(_productRepository.Object);
            var response = await handler.Handle(new GetAllProductsQuery(), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<QueryResult>());
        }
        [Test]
        public async Task When_Find_All_Products_Fail()
        {
            var handler = new GetAllProductsQueryHandler(_productRepository.Object);
            var response = await handler.Handle(null, new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<QueryResult>());
            Assert.IsTrue(((IEnumerable)response.Data).Cast<object>().ToList().Count == products.Count);
        }
    }
}
