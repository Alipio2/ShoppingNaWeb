using ShoppingNaWeb.Shared.Entities;

namespace ShoppingNaWeb.Domain.ShoppingContext.Entities
{
    public class Product : Entity
    {
        #region Atributos   
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public string Image { get; private set; }
        public int QuantityOnHand { get; private set; }

        #endregion

        #region Metodos
        public Product()
        {
                
        }
        public Product(string title, decimal price, string image, int quantityOnHand)
        {
            Title = title;
            Price = price;
            Image = image;
            QuantityOnHand = quantityOnHand;
        }

        public void DecreaseQuantity(int quantity) => QuantityOnHand -= quantity;
        #endregion
    }
}
