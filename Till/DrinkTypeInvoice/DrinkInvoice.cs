using System;
using System.Collections.Generic;
using Till.Data;
using Till.InvoiceFactory;
using Till.InvoiceInterface;

namespace Till.DrinkTypeInvoice
{
    public class DrinkInvoice : IInvoice
    {
        private IDrinkInvoice drinkInvoice;

        public DrinkInvoice(String itemName)
        {
            drinkInvoice = new DrinkInvoiceFactory().createDrinkInvoiceType(itemName);
        }

        public void AddFoods(List<Item> item)
        {
            drinkInvoice.AddFoods(item);
        }

        public void RemoveFood(List<Item> items)
        {
            drinkInvoice.RemoveFood(items);
        }

        public double TotalFoodCost(List<Item> item)
        {
            throw new NotImplementedException();
        }
    }
}
