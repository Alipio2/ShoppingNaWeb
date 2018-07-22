using Microsoft.AspNetCore.Mvc;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Handlers;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Inputs;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Shared.Commands;
using System;


namespace ShoppingNaWeb.Api.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly OrderCommandHandle _handler;

        public OrderController(IOrderRepository repository, OrderCommandHandle handler)
        {
            _repository = repository;
            _handler = handler;
        }


        [Route("v1/Order/Tests")]
        [HttpGet]
        public string Test()
        {
            return "Api Ok!";
        }

        [HttpPost]
        [Route("v1/Order")]
        public ICommandResult Post(RegisterOrderCommand command)
        {

            return _handler.Handle(command);
        }
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 10)]
        [HttpGet]
        [Route("v1/Order/{id}")]
        public OrderCommandResult GetByName(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpPut]
        [Route("v1/Order")]
        public ICommandResult Put(UpdateOrderComand command)
        {
            return _handler.HandleUpdate(command);
        }
    }
}
