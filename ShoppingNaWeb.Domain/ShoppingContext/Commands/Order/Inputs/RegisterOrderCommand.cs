using ShoppingNaWeb.Domain.ShoppingContext.Commands.OrderItem.Inputs;
using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;
using System;
using System.Collections.Generic;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Inputs
{
    public class RegisterOrderCommand : ICommand
    {
        public Guid CustomerId { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }

        public bool Valid()
        {           
            AssertionConcern.AssertArgumentNotEmpty(CustomerId.ToString(), "O CustomerId não pode ser nulo.");
            return true;
        }
    }
}
