using Supermarket_checkout.Interfaces;
using Supermarket_checkout.Models;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket_checkout.Services
{
    public class Checkout : ICheckout
    {
        private List<Item> basketItems;

        public Checkout()
        {
            basketItems = new List<Item>();
        }

        public void Scan(Item item)
        {
            basketItems.Add(item);
        }

        public int Total()
        {
            int totalPrice = 0;
            foreach (var item in basketItems)
            {
                totalPrice += item.UnitPrice;
            }
            return totalPrice;
        }
    }
}
