using FluentValidation;
using Moq;
using Nivello.Domain.Commands.Product.CommandHandlers;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Commands.Product.CommandHandlers
{
    public class DeleteProductCommandHandlerTest
    {
        private Mock<IProductRepository> _productRepository;
        private byte[] mockImage { get; set; } = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 };

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
        }

        [Test]
        public void AuctionsQueries_DeleteMethod_IsOk()
        {
            var product = new Infrastructure.Data.Model.Product("Tv 42 Polegadas", 200, mockImage, Guid.NewGuid(), null, null);
            Assert.IsFalse(product.IsDelete);
            product.DeleteEntity();
            Assert.IsTrue(product.IsDelete);
        }

        [Test]
        public void When_DeleteProductCommandHandler_InvalidParam_Faill()
        {
            var handle = new DeleteProductCommandHandler(_productRepository.Object);
            Assert.ThrowsAsync<ValidationException>(() => handle.Handle(new DeleteProductCommand(Guid.Empty), new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_DeleteProductCommandHandler_NotFound_Faill()
        {
            var handle = new DeleteProductCommandHandler(_productRepository.Object);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(value : null);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(new DeleteProductCommand(Guid.NewGuid()), new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_DeleteProductCommandHandler_IsOk()
        {
            var product = new Infrastructure.Data.Model.Product("Tv 42 Polegadas", 200, mockImage, Guid.NewGuid(), null, null);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(product);
            _productRepository.Setup(m => m.UpdateAsync(It.IsAny<Infrastructure.Data.Model.Product>())).Verifiable();
            var handle = new DeleteProductCommandHandler(_productRepository.Object);
            var result = handle.Handle(new DeleteProductCommand(Guid.NewGuid()), new System.Threading.CancellationToken()).Result;
            Assert.IsTrue(product.IsDelete);
            Assert.That(result, Is.InstanceOf<CommandResult>());
        }


    }
}
