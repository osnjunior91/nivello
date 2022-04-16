using Nivello.Domain.Queries.Products.Queries;
using Nivello.Infrastructure.Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nivello.Test.Domain.Test.Queries.Products.Queries
{
    public class ProductsQueriesTest
    {
        private List<Product> products;
        private byte[] mockImage { get; set; } = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [SetUp]
        public void Setup()
        {
            products = new List<Product>()
            {
                new Product("Tv 42 Polegadas", 200, mockImage, Guid.NewGuid(), null, null),
                new Product("Bicicleta", 500, mockImage, Guid.NewGuid(), null, null),
                new Product("Iphone 7", 400, mockImage, Guid.NewGuid(), null, null),
                new Product("Xbox One ", 450, mockImage, Guid.NewGuid(), null, null),
                new Product("Sansung s10", 350, mockImage, Guid.NewGuid(), null, null)
            };
        }
        [Test]
        public void ProductsQueries_GetAll_IsOk()
        {
            Assert.IsTrue(products.AsQueryable().Count(ProductsQueries.GetAll()) == products.Count);
            products[0].DeleteEntity();
            Assert.IsTrue(products.AsQueryable().Count(ProductsQueries.GetAll()) == products.Count - 1);

        }

        [Test]
        public void ProductsQueries_GetById_IsOk()
        {
            var product = products[0];
            Assert.IsTrue(products.AsQueryable().FirstOrDefault(ProductsQueries.GetById(product.Id)) == product);
        }
    }
}
