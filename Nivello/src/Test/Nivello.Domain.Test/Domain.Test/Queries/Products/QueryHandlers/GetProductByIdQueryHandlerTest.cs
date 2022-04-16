using Moq;
using Newtonsoft.Json;
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
    public class GetProductByIdQueryHandlerTest
    {
        private Product product;
        private Mock<IProductRepository> _productRepository;
        private byte[] mockImage { get; set; } = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [SetUp]
        public void Setup()
        {
             product = new Product("Tv 42 Polegadas", 200, mockImage, Guid.NewGuid(), null, null);
            _productRepository = new Mock<IProductRepository>();
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Product, bool>>>())).ReturnsAsync(product);
        }

        [Test]
        public async Task When_Find_ById_Product_IsOkAsync()
        {
            var handler = new GetProductByIdQueryHandler(_productRepository.Object);
            var response = await handler.Handle(new GetProductByIdQuery(Guid.NewGuid()), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<QueryResult>());
            Assert.IsTrue(JsonConvert.SerializeObject(response.Data).Equals(JsonConvert.SerializeObject(product)));            
        }

        [Test]
        public void When_Find_ById_Guid_Empty_Product_Faill()
        {
            var handler = new GetProductByIdQueryHandler(_productRepository.Object);
            Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(new GetProductByIdQuery(Guid.Empty), new System.Threading.CancellationToken()));
        }
    }
}
