using Supermarket_checkout.Interfaces;
using Supermarket_checkout.Models;
using System;

namespace Supermarket_checkout.Services
{
    public class Checkout : ICheckout
    {
        public void Scan(Item item)
        {
            throw new NotImplementedException();
        }

        public int Total()
        {
            throw new NotImplementedException();
        }
    }
}
