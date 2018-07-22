using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;
using System;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.OrderItem.Inputs
{
    public class RegisterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public bool Valid()
        {
            AssertionConcern.AssertArgumentNotEmpty(Product.ToString(), "O ProductId não pode ser nulo.");
            return true;
        }
    }
}
