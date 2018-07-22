using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingNaWeb.Domain.ShoppingContext.Entities;
using ShoppingNaWeb.Domain.ShoppingContext.Enums;

namespace ShoppingNaWeb.Tests.Entities
{
    [TestClass]
    public  class OrderTests
    {
        private Product _mouse ;
        private Product _monitor;
        private Order _order ;

        public Product Mouse { get => _mouse; set => _mouse = value; }
        public Product Monitor { get => _monitor; set => _monitor = value; }
        public Order Order { get => _order; set => _order = value; }


        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, Order.Status);
        }
        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, Order);
        }


        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            Order.AddItem(new OrderItem(Mouse, 5));
            Assert.AreEqual(Mouse.QuantityOnHand, 5);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            Order.AddItem(new OrderItem(Monitor, 5));
            Order.AddItem(new OrderItem(Mouse, 5));
            Assert.AreEqual(2, Order.Items.Count);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrder()
        {
            Assert.AreEqual(true, Order);
        }

        // Ao pagar um pedido, o status deve ser Foi PAGO 
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            Order.Pay();
            Assert.AreEqual(EOrderStatus.WasPaid, Order.Status);
        }       

        // Ao cancelar o pedido, o status deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            Order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, Order.Status);
        }       

      
    }
}
