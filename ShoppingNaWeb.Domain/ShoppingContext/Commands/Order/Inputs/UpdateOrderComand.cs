using ShoppingNaWeb.Domain.ShoppingContext.Enums;
using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;
using System;


namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Inputs
{
    public  class UpdateOrderComand : ICommand
    {
        public Guid CustomerId { get; set; }
        public Guid OrderId { get; set; }
        public EOrderStatus Status { get; set; }

        public bool Valid()
        {
            AssertionConcern.AssertArgumentNotEmpty(CustomerId.ToString(), "O CustomerId não pode ser nulo.");
            return true;
        }
    }
}
