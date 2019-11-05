namespace Supermarket_checkout.Models
{
    public class Item
    {
        public string Id { get; set; }
        public int UnitPrice { get; set; }
        public int ItemCountForSpecialPrice { get; set; }
        public int SpecialPrice { get; set; }
    }
}
 