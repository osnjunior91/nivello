using Nivello.Domain.Queries.Customer.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nivello.Test.Domain.Test.Queries.Customer.Queries
{
    public class CustomerQueriesTest
    {
        private List<Infrastructure.Data.Model.Customer> customers;

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
        }

        [Test]
        public void CustomerQueries_Name_Null_IsOk()
        {
            var response = customers.AsQueryable().Count(CustomerQueries.GetByName(null));
            Assert.IsTrue(response == customers.Count);
        }

        [Test]
        public void CustomerQueries_Name_Empty_IsOk()
        {
            var response = customers.AsQueryable().Count(CustomerQueries.GetByName(string.Empty));
            Assert.IsTrue(response == customers.Count);
        }

        [Test]
        public void CustomerQueries_Name_IsOk()
        {
            var response = customers.AsQueryable().Count(CustomerQueries.GetByName("1"));
            Assert.IsTrue(response == 1);
        }

        [Test]
        public void CustomerQueries_ById_IsOk()
        {
            var response = customers.AsQueryable().Count(CustomerQueries.GetById(customers[0].Id));
            Assert.IsTrue(response == 1);
        }

    }
}
