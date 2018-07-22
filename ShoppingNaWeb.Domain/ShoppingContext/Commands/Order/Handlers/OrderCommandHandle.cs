using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Inputs;
using ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Results;
using ShoppingNaWeb.Domain.ShoppingContext.Contracts.Repositories;
using ShoppingNaWeb.Shared.Commands;

namespace ShoppingNaWeb.Domain.ShoppingContext.Commands.Order.Handlers
{
    public class OrderCommandHandle : ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandle(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }
        public ICommandResult Handle(RegisterOrderCommand command)
        {
            // Instancia o cliente (Lendo do repositorio)
            var customer = _customerRepository.Get(command.CustomerId);
            // Gera um novo pedido
            var order = new Entities.Order(customer, command.DeliveryFee, command.Discount);
            // Adiciona os itens no pedido
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new Entities.OrderItem(product, item.Quantity));
            }
            // Persiste no banco
            _orderRepository.Create(order);
           return new OrderCommandResult(true,"Pedido Criado com sucesso!", order.Number);
        }

        public ICommandResult HandleUpdate(UpdateOrderComand command)
        {
            // Obter o cliente (Lendo do repositorio)
            var customer = _customerRepository.Get(command.CustomerId);
            // Obter o pedido     
            var order = _orderRepository.GetById(command.OrderId);
            // Alterar o pedido
            order.ToChangeStatus(command.Status);
            // Persiste no banco
            _orderRepository.Save(order);
            return new OrderCommandResult(true, "Pedido Alterado com sucesso!", order.Number);
        }
    }
}
