using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Domain.ShoppingContext.ValueObjects;
using ShoppingNaWeb.Shared.Commands;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Handlers
{
    public class CustomerCommandHandler : ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            // Passo 1. Verificar se o CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {                  
                return new CustomerCommandResult(false, "Este CPF já está em uso!", null);
            }

            // Passo 2. Gerar o novo cliente           
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);           
            var customer = new Entities.Customer(name, email, document);

            // Passo 3. Inserir no banco
            _customerRepository.Create(customer);

            // Passo 4. Retornar algo
            return new CustomerCommandResult(true, "Usuario Cadastrado Com Sucesso!", customer);
        }
    }
}
