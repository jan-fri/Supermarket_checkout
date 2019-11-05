using NUnit.Framework;
using Supermarket_checkout.Models;
using Supermarket_checkout.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Supermarket_checkout_test
{
    public class Checkout_Tests
    {
        private Checkout _checkout = new Checkout();
        private List<Item> _itemList;

        [SetUp]
        public void Setup()
        {
            CreateItemList();
        }

        [TestCase("A,B,C,D", 115)]
        public void SumItems_ShouldReturnTotalPrice(string itemIds, int expectedTotalPrice)
        {
            //Arrange
            var shoppingBasket = AddItemsToShoppingBasket(itemIds);

            //Act
            foreach (var item in shoppingBasket)
            {
                _checkout.Scan(item);
            }            
            var calculatedTotalPrice = _checkout.Total();

            //Assert
            Assert.AreEqual(expectedTotalPrice, calculatedTotalPrice);
        }

        private List<Item> AddItemsToShoppingBasket(string itemIds)
        {
            var itemList = itemIds.Split(',');
            List<Item> shoppingBasketList = new List<Item>();
            foreach (var itemId in itemList)
            {
                var item = _itemList.Where(x => x.Id == itemId).First();
                shoppingBasketList.Add(item);
            }

            return shoppingBasketList;
        }

        private void CreateItemList()
        {
            _itemList = new List<Item>
            {
                new Item{ Id = "A", UnitPrice = 50, UnitSpecialPrice = 3, SpecialPrice = 130 },
                new Item{ Id = "B", UnitPrice = 30, UnitSpecialPrice = 2, SpecialPrice = 45 },
                new Item{ Id = "C", UnitPrice = 20 },
                new Item{ Id = "D", UnitPrice = 15 }
            };
        }
    }
}