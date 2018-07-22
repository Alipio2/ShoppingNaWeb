using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using System;

namespace ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories
{
    public interface IProductRepository : IDisposable
    {
        Product Get(Guid id);
       
    }
}
