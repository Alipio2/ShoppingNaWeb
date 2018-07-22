using System;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;

namespace ShoppingNaWeb.Tests.Repository
{

    public class FakeCustomerRepository : ICustomerRepository
    {
        public void Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool DocumentExists(string document)
        {
            return true;
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerCommandResult Get(string username)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
