using FluentValidation;
using Moq;
using Nivello.Domain.Commands.Auctions.CommandHandlers;
using Nivello.Domain.Commands.Auctions.Commands;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Auctions;
using Nivello.Infrastructure.Data.Repository.Products;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Commands.Auctions.CommandHandlers
{
    public class CreateAuctionsBidCommandHandlerTest
    {
        private Mock<IAuctionsBidRepository> _auctionsBidRepository;
        private Mock<IProductRepository> _productRepository;

        [SetUp]
        public void Setup()
        {
            _auctionsBidRepository = new Mock<IAuctionsBidRepository>();
            _productRepository = new Mock<IProductRepository>();
            var product = new Infrastructure.Data.Model.Product("Tv 42 Polegadas", 200, null, Guid.NewGuid(), null, null);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(product);
        }

        [TestCase("00000000-0000-0000-0000-000000000000", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 10)]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "00000000-0000-0000-0000-000000000000", 20)]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 0)]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", -20)]
        public void When_CreateAuctionsBidCommandHandler_InvalidParam_Faill(Guid productId, Guid customerId, float amount)
        {
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            Assert.ThrowsAsync<ValidationException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 200)]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 199)]
        public void When_Amount_LessThanLastBid_Faill(Guid productId, Guid customerId, float amount)
        {
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(new AuctionsBid(Guid.NewGuid(), Guid.NewGuid(), 200));
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 201)]
        public void When_HasOldBid_NewBid_IsOk(Guid productId, Guid customerId, float amount)
        {
            var oldBid = new AuctionsBid(Guid.NewGuid(), Guid.NewGuid(), 200);
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(oldBid);
            _auctionsBidRepository.Setup(m => m.CreatedAndUpdateAsync(It.IsAny<AuctionsBid>(), It.IsAny<AuctionsBid>())).Verifiable();
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());
            Assert.IsFalse(oldBid.IsActive);
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 200)]
        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 199)]
        public void When_Amount_LessThanProductPrice_Faill(Guid productId, Guid customerId, float amount)
        {
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(value: null);
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 200)]
        public void When_Product_NotFound_Faill(Guid productId, Guid customerId, float amount)
        {
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(value: null);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(value: null);
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 201)]
        public void When_Product_Exists_IsOk(Guid productId, Guid customerId, float amount)
        {
            var product = new Infrastructure.Data.Model.Product("Tv 42 Polegadas", 200, null, Guid.NewGuid(), null, null);
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(product);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(value: null);
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());
        }

        [TestCase("127f0c34-d774-44d4-8d9e-d3c3df8af908", "127f0c34-d774-44d4-8d9e-d3c3df8af908", 201)]
        public void When_Product_IsDelete_Fail(Guid productId, Guid customerId, float amount)
        {
            var product = new Infrastructure.Data.Model.Product("Tv 42 Polegadas", 200, null, Guid.NewGuid(), null, null);
            product.DeleteEntity();
            CreateAuctionsBidCommand command = new CreateAuctionsBidCommand(productId, customerId, amount);
            _productRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Product, bool>>>())).ReturnsAsync(product);
            _auctionsBidRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<AuctionsBid, bool>>>())).ReturnsAsync(value: null);
            var handle = new CreateAuctionsBidCommandHandler(_auctionsBidRepository.Object, _productRepository.Object);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }
    }
}
