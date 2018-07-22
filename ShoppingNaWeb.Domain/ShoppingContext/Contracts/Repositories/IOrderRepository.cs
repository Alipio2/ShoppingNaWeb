using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using System;

namespace ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories
{
    public interface IOrderRepository : IDisposable
    {
        void Save(Order order);
        void Create(Order order);

        OrderCommandResult Get(Guid id);

        Order GetById(Guid id);

    }
}
