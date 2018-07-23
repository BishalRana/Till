using System;
using System.Collections.Generic;
using System.Diagnostics;
using Till.Data;
using Till.InvoiceFactory;
using Till.InvoiceInterface;

namespace Till.BentoTypeInvoice
{
    public class BentoInvoice : IInvoice
    {
        private IBentoInvoice bentoInvoice;

        public BentoInvoice(String itemName)
        {
            bentoInvoice = new BentoInvoiceFactory().createBentoInvoiceType(itemName);
        }

        public void AddFoods(List<Item> item)
        {
            bentoInvoice.AddFoods(item);
        }

        public void RemoveFood(List<Item> items)
        {
            bentoInvoice.RemoveFood(items);
        }

        public double TotalFoodCost(List<Item> item)
        {
            throw new NotImplementedException();
        }
    }
}
