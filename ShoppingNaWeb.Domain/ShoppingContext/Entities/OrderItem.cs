using ShoppingNaWeb.Shared.Entities;
using ShoppingNaWeb.Shared.Validation;

namespace ShoppingNaWeb.Domain.ShoppingContext.Entities
{
    public class OrderItem : Entity
    {
        #region Atributos        
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        #endregion

        #region Metodos
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            AssertionConcern.AssertArgumentIsBiggerThan(Price, 0, "A O preco nao pode ser zero!");
            AssertionConcern.AssertArgumentRange(Quantity,1 ,10000000, "A Quantidete tem que ser maior que zero");            
        }

        public decimal Total() => Price * Quantity;
        #endregion
    }
}
