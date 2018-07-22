using ShoppingNaWeb.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Product.Results
{
    public class ProductListCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ProductListCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
