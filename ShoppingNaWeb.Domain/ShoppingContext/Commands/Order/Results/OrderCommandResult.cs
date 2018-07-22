using ShoppingNaWeb.Shared.Commands;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Results
{
    public class OrderCommandResult : ICommandResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OrderCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
    }
}
