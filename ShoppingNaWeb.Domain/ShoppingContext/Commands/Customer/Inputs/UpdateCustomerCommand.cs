using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;
using System;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs
{
    public class UpdateCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public bool Valid()
        {
            AssertionConcern.AssertArgumentNotEmpty(FirstName, "O Nome não pode ser nulo.");
            AssertionConcern.AssertArgumentMinLength(FirstName, 4, "O nome deve conter pelo menos 4 caracteres");
            AssertionConcern.AssertArgumentMaxLength(FirstName, 30, "O nome deve conter no máximo 30 caracteres");
           
            return true;
        }
    }
}
