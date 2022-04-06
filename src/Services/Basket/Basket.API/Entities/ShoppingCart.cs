using System.Collections.Generic;

namespace Basket.API.Controllers.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; }

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public ShoppingCart()
        {

        }

        public ShoppingCart(string username)
        {
            Username = username;
        }

        public decimal GetTotalPrice
        {
            get
            {
                decimal total = 0;

                foreach (ShoppingCartItem item in Items)
                {
                    total += item.Price * item.Quantity;
                }

                return total;
            }
        }
    }
}
