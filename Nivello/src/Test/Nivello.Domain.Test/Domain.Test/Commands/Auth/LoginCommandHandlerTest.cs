using FluentValidation;
using Microsoft.Extensions.Configuration;
using Moq;
using Nivello.Domain.Commands.Auth.CommandHandlers;
using Nivello.Domain.Commands.Auth.Commands;
using Nivello.Infrastructure.Data.Model;
using Nivello.Infrastructure.Data.Repository.Admins;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Commands.Auth
{
    public class LoginCommandHandlerTest
    {
        private Mock<ICustomerRepository> _customerRepository;
        private Mock<IAdminRepository> _adminRepository;
        private Mock<IConfiguration> _configuration;

        [SetUp]
        public void Setup()
        {
            _customerRepository = new Mock<ICustomerRepository>();
            _adminRepository = new Mock<IAdminRepository>();
            _configuration = new Mock<IConfiguration>();
            
            _configuration.SetupGet(x => x[It.Is<string>(s => s == "SecretKey")]).Returns("DmSAzDlUXRak7hdXwY2em5sdKOmXz83F");

        }

        [TestCase("email", "123456")]
        [TestCase("", "123456")]
        [TestCase("email@email.com", "")]
        public void When_LoginCommandHandler_InvalidParam_Faill(string email, string password)
        {
            var handle = new LoginCommandHandler(_customerRepository.Object, _adminRepository.Object, _configuration.Object);
            var command = new LoginCommand(email, password, false);
            Assert.ThrowsAsync<ValidationException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_LoginCustomer_InvalidUser_Faill()
        {
            var command = new LoginCommand("email@email.com", "123456", false);
            var handle = new LoginCommandHandler(_customerRepository.Object, _adminRepository.Object, _configuration.Object);
            _customerRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Customer, bool>>>())).ReturnsAsync(value: null);
            Assert.ThrowsAsync<ArgumentException>(() => handle.Handle(command, new System.Threading.CancellationToken()));
        }

        [Test]
        public void When_LoginCustomer_IsOk()
        {
            var command = new LoginCommand("email@email.com", "123456", false);
            var customer = new Infrastructure.Data.Model.Customer("Nome Customer","email@email.com", "123456", DateTime.Now.AddYears(-30));
            var handle = new LoginCommandHandler(_customerRepository.Object, _adminRepository.Object, _configuration.Object);
            _customerRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Customer, bool>>>())).ReturnsAsync(customer);
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(GetClaimRole(result.Data.ToString()).Equals("Customer"));
        }

        [Test]
        public void When_LoginAdmin_IsOk()
        {
            var command = new LoginCommand("email@email.com", "123456", true);
            var customer = new SystemAdmin("Nome Customer", "email@email.com", "123456");
            var handle = new LoginCommandHandler(_customerRepository.Object, _adminRepository.Object, _configuration.Object);
            _adminRepository.Setup(m => m.FirstOrDefaultAsync(It.IsAny<Expression<Func<SystemAdmin, bool>>>())).ReturnsAsync(customer);
            var result = handle.Handle(command, new System.Threading.CancellationToken()).Result;
            Assert.That(result, Is.InstanceOf<CommandResult>());
            Assert.IsTrue(GetClaimRole(result.Data.ToString()).Equals("Admin"));
        }

        private string GetClaimRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            return jwtSecurityToken.Claims.First(claim => claim.Type == "role")?.Value;
        }
    }
}
