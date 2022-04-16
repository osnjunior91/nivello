using Nivello.Domain.Queries.Auth.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nivello.Test.Domain.Test.Queries.Auth.Queries
{
    public class AuthQueriesTest
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
        public void AuthQueries_Login_IsOk()
        {
            var response = customers.AsQueryable().Count(AuthQueries<Infrastructure.Data.Model.Customer>.LoginQuery("nome1@teste.com", "123456"));
            Assert.IsTrue(response == 1);
        }

    }
}
