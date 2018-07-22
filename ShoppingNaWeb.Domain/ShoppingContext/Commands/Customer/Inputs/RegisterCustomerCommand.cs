using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs
{
    public class RegisterCustomerCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }       
      

        public bool Valid()
        {
            AssertionConcern.AssertArgumentNotEmpty(FirstName, "O Nome não pode ser nulo.");
            AssertionConcern.AssertArgumentMinLength(FirstName, 4, "O nome deve conter pelo menos 4 caracteres");
            AssertionConcern.AssertArgumentMaxLength(FirstName, 30, "O nome deve conter no máximo 30 caracteres");           
            AssertionConcern.AssertArgumentNotEmpty(Email, "O Cpf não pode ser nulo.");
            AssertionConcern.AssertArgumentNotEmpty(Document, "O Nome não pode ser nulo.");
            return true;
        }
    }
}
