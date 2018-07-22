using ShoppingNaWeb.Domain.ShoppingContext.Enums;
using ShoppingNaWeb.Shared.Entities;
using ShoppingNaWeb.Shared.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingNaWeb.Domain.ShoppingContext.Entities
{
    public class Order : Entity
    {
        #region Atributos        
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public decimal Discount { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }

        private readonly IList<OrderItem> _items;
        #endregion

        #region Metodos

        public Order()
        {
                
        }

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;
            _items = new List<OrderItem>();

            AssertionConcern.AssertArgumentIsBiggerThan(DeliveryFee, -1, "A Taxa de entregra não pode ser negativo");
            AssertionConcern.AssertArgumentIsBiggerThan(Discount, -1, "O Desconto nao pode ser negativo");            

        }

        public ICollection<OrderItem> Items => _items.ToArray();

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            _items.Add(item);
        }

        public void ToChangeStatus(EOrderStatus status)
        {
            Status = status;
        }

        public void Pay() {

            Status = EOrderStatus.WasPaid;
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
        }
        #endregion
    }
}
