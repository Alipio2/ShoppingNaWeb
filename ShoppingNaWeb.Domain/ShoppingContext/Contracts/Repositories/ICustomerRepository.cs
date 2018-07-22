using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        Customer Get(Guid id);        
        CustomerCommandResult Get(string username);
        void Create(Customer customer);
        void Save(Customer customer);       
        bool DocumentExists(string document);
    }
}
