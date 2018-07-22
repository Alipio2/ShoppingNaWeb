using Microsoft.AspNetCore.Mvc;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Product.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using System;

namespace ShoppingNaWeb.Api.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }
        

        [Route("v1/Product/Tests")]
        [HttpGet]        
        public string Test()
        {
            return "Api Ok!";
        }
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 10)]
        [HttpGet]
        [Route("v1/Order/{id}")]
        public ProductListCommandResult Get(Guid id)
        {
            var result = _repository.Get(id);
            return new ProductListCommandResult(true, "Ok", result);
        }
    }
}
