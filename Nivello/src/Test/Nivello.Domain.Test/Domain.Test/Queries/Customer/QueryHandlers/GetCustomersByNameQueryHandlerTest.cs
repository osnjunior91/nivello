using Moq;
using Nivello.Domain.Queries.Customer.Queries;
using Nivello.Domain.Queries.Customer.QueryHandlers;
using Nivello.Infrastructure.Data.Repository.Customers;
using Nivello.Lib.Nivello.Lib.Domain.Queries;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Queries.Customer.QueryHandlers
{
    public class GetCustomersByNameQueryHandlerTest
    {
        private List<Infrastructure.Data.Model.Customer> customers;
        private Mock<ICustomerRepository> _customerRepository;

        [SetUp]
        public void Setup()
        {
           
            customers = new List<Infrastructure.Data.Model.Customer>()
            {
                new Infrastructure.Data.Model.Customer("Nome 1", "nome1@teste.com", "123456", DateTime.Now),
                new Infrastructure.Data.Model.Customer("Nome 2", "nome2@teste.com", "123456", DateTime.Now),
                new Infrastructure.Data.Model.Customer("Nome 3", "nome3@teste.com", "123456", DateTime.Now),
                new Infrastructure.Data.Model.Customer("Nome 4", "nome4@teste.com", "123456", DateTime.Now)
            };
            _customerRepository = new Mock<ICustomerRepository>();
            _customerRepository.Setup(m => m.WhereAsync(It.IsAny<Expression<Func<Infrastructure.Data.Model.Customer, bool>>>())).ReturnsAsync(customers);
        }

        [Test]
        public async Task When_Find_All_Customers_IsOkAsync()
        {
            var handler = new GetCustomersByNameQueryHandler(_customerRepository.Object);
            var response = await handler.Handle(new GetCustomersByNameQuery(string.Empty), new System.Threading.CancellationToken());
            Assert.That(response, Is.InstanceOf<QueryResult>());
            Assert.IsTrue(((IEnumerable)response.Data).Cast<object>().ToList().Count == customers.Count);
        }

    }
}
