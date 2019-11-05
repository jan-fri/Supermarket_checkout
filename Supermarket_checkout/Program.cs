using Microsoft.Extensions.DependencyInjection;
using Supermarket_checkout.Interfaces;
using Supermarket_checkout.Models;
using Supermarket_checkout.Services;
using System;
using System.Collections.Generic;

namespace Supermarket_checkout
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection();
            SetupDI(serviceProvider);
            serviceProvider.BuildServiceProvider();

            RunProgram();         
        }

        private static void RunProgram()
        {
            var checkout = new Checkout();
            Console.WriteLine("Calculating basket price for items ");

            var itemBasketList = CreateItemList();
            foreach (var item in itemBasketList)
            {
                Console.WriteLine($"Id: {item.Id}, Unit price: {item.UnitPrice}, Special price: {item.ItemCountForSpecialPrice} for {item.SpecialPrice}");
                checkout.Scan(item);
            }
            
            Console.WriteLine($"Total price: {checkout.Total()}");
        }

        private static void SetupDI(ServiceCollection serviceProvider)
        {
            serviceProvider.AddTransient<ICheckout, Checkout>();           
        }

        private static List<Item> CreateItemList()
        {
            return new List<Item>
            {
                new Item{ Id = "B", UnitPrice = 30, ItemCountForSpecialPrice = 2, SpecialPrice = 45 },
                new Item{ Id = "A", UnitPrice = 50, ItemCountForSpecialPrice = 3, SpecialPrice = 130 },
                new Item{ Id = "B", UnitPrice = 30, ItemCountForSpecialPrice = 2, SpecialPrice = 45 },
            };
        }
    }
}
