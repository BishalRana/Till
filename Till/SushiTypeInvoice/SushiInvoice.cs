using System;
using System.Collections.Generic;
using Till.Data;
using Till.InvoiceFactory;
using Till.InvoiceInterface;

namespace Till.SushiTypeInvoice
{
    public class SushiInvoice : IInvoice
    {
        private IShushiInvoice sushiInvoice;
        public SushiInvoice(string itemName)
        {
            sushiInvoice = new SushiInvoiceFactory().createSushuInvoiceType(itemName);
        }

        public void AddFoods(List<Item> items)
        {
            sushiInvoice.AddFoods(items);
        }

        public void RemoveFood(List<Item> items)
        {
            sushiInvoice.RemoveFood(items);      
        }

        public double TotalFoodCost(List<Item> item)
        {
            throw new NotImplementedException();
        }
    }
}
