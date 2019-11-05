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
            int totalPrice = CalculateTotalPrice();
            return totalPrice;
        }

        private int CalculateTotalPrice()
        {
            int totalPrice = 0;
            var basketItemIdCount = basketItems.GroupBy(x => new { x.Id })
                            .Select(group => new { ItemId = group.Key, Count = group.Count() })
                            .ToList();

            foreach (var item in basketItemIdCount)
            {
                var basketItem = basketItems.Where(x => x.Id == item.ItemId.Id).First();
                totalPrice += basketItem.ItemCountForSpecialPrice != 0
                    ? GetSpecialPrice(item.Count, basketItem)
                    : item.Count * basketItem.UnitPrice;
            }

            return totalPrice;
        }

        private int GetSpecialPrice(int itemCount, Item basketItem)
        {
            var UnitSpecialCountMultiplier = itemCount / basketItem.ItemCountForSpecialPrice;
            var specialPrice = basketItem.SpecialPrice * UnitSpecialCountMultiplier;

            var itemCountReminder = itemCount % basketItem.ItemCountForSpecialPrice;
            var reminderPrice = itemCountReminder * basketItem.UnitPrice;
            return specialPrice + reminderPrice;
        }
    }
}
