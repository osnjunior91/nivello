using FluentValidation;
using Moq;
using Nivello.Domain.Commands.Customer.CommandHandlers;
using Nivello.Domain.Commands.Customer.Commands;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using NUnit.Framework;
using System;

namespace Nivello.Test.Domain.Test.Commands.Customer.CommandHandlers
{
    public class CreateCustomerCommandHandlerTest
    {
        private Mock<ICustomerRepository> _customerRepository;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<ICustomerRepository>();
        }

        [TestCase("", "email@email.com", "123456", "10/22/2000")]
        [TestCase("Nome pessoa", "", "123456", "10/22/2000")]
        [TestCase("Nome pessoa", "email@email.com", "", "10/22/2000")]
        [TestCase("Nome pessoa", "email@email.com", "123456", "10/22/2015")]
        public void When_CreateCustomerCommandHandlerTest_InvalidParam_Faill(string name, string email, string password, DateTime dateOfBirth)
        {
            var handle = new CreateCustomerCommandHandler(_customerRepository.Object);
            var command = new CreateCustomerCommand(name, email, password, dateOfBirth);
            Assert.ThrowsAsync<ValidationException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_CreateCustomerCommandHandler_IsOk()
        {
            _customerRepository.Setup(m => m.CreatedAsync(It.IsAny<Infrastructure.Data.Model.Customer>())).Verifiable();
            var handle = new CreateCustomerCommandHandler(_customerRepository.Object);
            var command = new CreateCustomerCommand("Nome pessoa", "email@email.com", "123456", DateTime.Now.AddYears(-30));
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());

        }
    }
}
