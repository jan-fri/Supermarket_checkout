using Supermarket_checkout.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Supermarket_checkout.Interfaces
{
    public interface ICheckout
    {
        void Scan(Item item);
        int Total();
    }
}
