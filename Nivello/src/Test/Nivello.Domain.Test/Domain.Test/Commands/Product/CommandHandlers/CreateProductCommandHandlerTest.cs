using FluentValidation;
using Microsoft.AspNetCore.Http;
using Moq;
using Nivello.Domain.Commands.Product.CommandHandlers;
using Nivello.Domain.Commands.Product.Commands;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Extension.Methods;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Commands.Product.CommandHandlers
{
    public class CreateProductCommandHandlerTest
    {
        private Mock<IProductRepository> _productRepository;
        IFormFile photoMock;

        [SetUp]
        public void Setup()
        {
            _productRepository = new Mock<IProductRepository>();
            photoMock = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("dummy image")), 0, 0, "Data", "image.png");
        }

        [TestCase("", 200, true, "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        [TestCase("Nome do Produto", 200, false, "127f0c34-d774-44d4-8d9e-d3c3df8af908")]
        [TestCase("Nome do Produto", 200, true, "00000000-0000-0000-0000-000000000000")]
        public void When_CreateProductCommandHandler_InvalidParam_Faill(string name, float price, bool hasFile, Guid systemAdminId)
        {
            var handle = new CreateProductCommandHandler(_productRepository.Object);
            var command = new CreateProductCommand(name, price, (hasFile) ? photoMock : null, systemAdminId);
            Assert.ThrowsAsync<ValidationException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_CreateProductCommandHandler_IsOk()
        {
           
            var command = new CreateProductCommand("Nome do Produto", 200, photoMock, Guid.NewGuid());
            _productRepository.Setup(m => m.CreatedAsync(It.IsAny<Infrastructure.Data.Model.Product>())).Verifiable();
            var handle = new CreateProductCommandHandler(_productRepository.Object);
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());
        }
    }
}
