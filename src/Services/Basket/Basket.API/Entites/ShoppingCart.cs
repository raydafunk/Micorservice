using System.Collections.Generic;

namespace Basket.API.Entites
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartCartItem> Items { get; set; } = new List<ShoppingCartCartItem>();

        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (var item in Items)
                {
                    totalprice += item.Price = item.Quantity;
                }
                return totalprice;

            }   
        }
    }
}
