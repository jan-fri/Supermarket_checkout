using Supermarket_checkout.Models;

namespace Supermarket_checkout.Interfaces
{
    public interface ICheckout
    {
        void Scan(Item item);
        int Total();
    }
}
