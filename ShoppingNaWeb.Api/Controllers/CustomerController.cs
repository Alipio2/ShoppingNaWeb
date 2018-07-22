using Microsoft.AspNetCore.Mvc;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Handlers;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Inputs;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Shared.Commands;
using ShoppingNaWeb.Shared.Validation;
using System.Net;

namespace ShoppingNaWeb.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerCommandHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerCommandHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [Route("v1/Customer/Tests")]
        [HttpGet]
        public string Test()
        {
            return "Api Ok!";
        }

        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 10)]
        [HttpGet]
        [Route("v1/customers/{name}")]
        public CustomerCommandResult GetByName(string name)
        {
            AssertionConcern.AssertArgumentNotEmpty(name.ToString(), "O Nome não pode ser nulo.");
            return _repository.Get(name);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post(RegisterCustomerCommand command)
        {
            //fail fast validation
            AssertionConcern.AssertArgumentNotEmpty(command.FirstName, "O Primeiro nome não pode ser nulo.");
            AssertionConcern.AssertArgumentNotEmpty(command.Email, "O email nome não pode ser nulo.");
            return _handler.Handle(command); 
        }
    }
}
