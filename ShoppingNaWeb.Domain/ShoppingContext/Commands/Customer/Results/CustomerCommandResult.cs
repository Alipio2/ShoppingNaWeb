using ShoppingNaWeb.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Customer.Results
{
    public class CustomerCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public CustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }       
    }
}
