using System;
namespace Till.Data
{
    public class Item
    {
        public string itemName { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public double totalCost
        {
            get;
            set;
        }
        public string type;

        public Item()
        {

        }
        public Item(double price)
        {
            this.price = price;
        }

        public Item(string itemName, double price)
        {
            this.itemName = itemName;
            this.price = price;
        }
    }
}
